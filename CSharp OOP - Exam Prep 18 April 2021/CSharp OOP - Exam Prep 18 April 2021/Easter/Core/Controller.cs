using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        public Controller()
        {
            bunnies = new BunnyRepository(); 
            eggs = new EggRepository();
        } 

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }
            bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            if (bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }
            bunnies.FindByName(bunnyName).AddDye(new Dye(power));
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            eggs.Add(new Egg(eggName, energyRequired));
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            IWorkshop workshop = new Workshop();
            var selectedEgg = eggs.FindByName(eggName);
            var selectedBunnies = bunnies.Models.OrderByDescending(b=>b.Energy).TakeWhile(b=>b.Energy >= 50).ToList();
            if (!selectedBunnies.Any())
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            foreach (var bunny in selectedBunnies)
            {
                workshop.Color(selectedEgg, bunny);
                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
            }
            if (selectedEgg.IsDone())
            {
               return  $"Egg {eggName} is done.";
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Where(e=>e.IsDone() == true).ToList().Count} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Where(x=>x.IsFinished() == false).ToList().Count} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
