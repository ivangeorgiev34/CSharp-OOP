using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {

        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.CanBreath) // cant breathe
                {
                    int itemsToRemove = 0;
                    List<string> strings = new List<string>();  
                    foreach (var item in planet.Items)
                    {
                        if (astronaut.CanBreath)
                        {
                            astronaut.Bag.Items.Add(item);
                            astronaut.Breath();
                            itemsToRemove++;
                            strings.Add(item);
                        }
                        else
                        {
                            break;
                        }
                    }
                    foreach (var item in strings)
                    {
                        planet.Items.Remove(item);
                    }
                }
            }
        }
    }
}
