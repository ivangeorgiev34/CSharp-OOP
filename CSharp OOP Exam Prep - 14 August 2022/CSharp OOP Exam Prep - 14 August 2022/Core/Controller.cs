using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            else if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            else if (planets.Models.FirstOrDefault(p => p.Name == planetName).Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }
            IMilitaryUnit unit = null;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            planets.Models.FirstOrDefault(p => p.Name == planetName).Spend(unit.Cost);
            planets.Models.FirstOrDefault(p => p.Name == planetName).AddUnit(unit);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            else if (weaponTypeName != "SpaceMissiles" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "BioChemicalWeapon")
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            else if (planets.Models.FirstOrDefault(p => p.Name == planetName).Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }
            //todo check here
            IWeapon weapon = null;
            if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            planets.Models.FirstOrDefault(p => p.Name == planetName).Spend(weapon.Price);
            planets.Models.FirstOrDefault(p => p.Name == planetName).AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(p => p.Name == name))
            {
                return $"Planet {name} is already added!";
            }
            planets.AddItem(new Planet(name, budget));
            return $"Successfully added Planet: {name}";
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");
            var orderedPlanets = planets.Models.OrderByDescending(m => m.MilitaryPower).ThenBy(n => n.Name);
            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.Models.FirstOrDefault(p => p.Name == planetOne);
            var secondPlanet = planets.Models.FirstOrDefault(p => p.Name == planetTwo);

            bool firstPlanetWins = false;
            bool secondPlanetWins = false;
            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if ((firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")) || (!firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && !secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if ((firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")) && !(secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")))
                {
                    firstPlanetWins=true;
                }
                else if (!(firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")) && (secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")))
                {
                    secondPlanetWins = true;
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                firstPlanetWins = true;
            }
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                secondPlanetWins = true;
            }

            if (firstPlanetWins)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Army.Sum(u => u.Cost) + secondPlanet.Weapons.Sum(w => w.Price));
                planets.RemoveItem(secondPlanet.Name);

                return $"{firstPlanet.Name} destructed {secondPlanet.Name}!";
            }
            if (secondPlanetWins)
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Army.Sum(u => u.Cost) + firstPlanet.Weapons.Sum(w => w.Price));
                planets.RemoveItem(firstPlanet.Name);

                return $"{secondPlanet.Name} destructed {firstPlanet.Name}!";
            }
            return "";
        }

        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            else if (planets.Models.FirstOrDefault(p => p.Name == planetName).Army.Count == 0)
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }
            planets.Models.FirstOrDefault(p => p.Name == planetName).Spend(1.25);
            planets.Models.FirstOrDefault(p => p.Name == planetName).TrainArmy();

            return $"{planetName} has upgraded its forces!";
        }
    }
}
