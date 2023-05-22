using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller  : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            aquariums.Add(aquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fish.GetType().Name == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (fish.GetType().Name == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium")
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return "Water not suitable.";
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal value = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(f => f.Price);
            return $"The value of Aquarium {aquarium.Name} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
