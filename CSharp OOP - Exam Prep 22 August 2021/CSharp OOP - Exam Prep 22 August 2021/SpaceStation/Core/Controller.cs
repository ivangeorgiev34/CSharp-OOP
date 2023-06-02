using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanets=0;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            if (type != "Geodesist" && type != "Biologist" && type != "Meteorologist")
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            IAstronaut astronaut = null;
            if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            astronauts.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IMission mission = new Mission();
            IPlanet planet = planets.FindByName(planetName);
            var suitableAstronauts = new List<IAstronaut>();
            foreach (var astronaut in astronauts.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    suitableAstronauts.Add(astronaut);
                }
            }
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            mission.Explore(planet, suitableAstronauts);
            exploredPlanets++;
            return $"Planet: {planetName} was explored! Exploration finished with {suitableAstronauts.Where(a=>a.CanBreath == false).ToList().Count} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ",astronaut.Bag.Items)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (!astronauts.Models.Any(a => a.Name == astronautName))
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            var astronautToRemove = astronauts.Models.FirstOrDefault(a => a.Name == astronautName);
            astronauts.Remove(astronautToRemove);
            return $"Astronaut {astronautName} was retired!";

        }
    }
}
