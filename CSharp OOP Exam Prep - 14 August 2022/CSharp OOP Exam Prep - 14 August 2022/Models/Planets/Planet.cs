using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository units;
        private WeaponRepository weapons;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }
                name = value;
            }
        }
        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }
                budget = value;
            }
        }
        public double MilitaryPower => Math.Round(CalculateMilitaryPower(), 3);
        


        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            //sb.Append(Environment.NewLine);
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            if (units.Models.Count == 0)
            {
                sb.AppendLine($"--Forces: No units");
            }
            else
            {
                sb.AppendLine($"--Forces: {string.Join(", ", units.Models.Select(x => x.GetType().Name))}");
            }
            if (weapons.Models.Count == 0)
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ", weapons.Models.Select(x => x.GetType().Name))}");
            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget = this.Budget + amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException("Budget too low!");
            }
            Budget = Budget - amount;
        }

        public void TrainArmy()
        {
            foreach (var item in units.Models)
            {
                item.IncreaseEndurance();
            }
        }
        public double CalculateMilitaryPower()
        {
            double totalAmount = Army.Sum(e => e.EnduranceLevel) + Weapons.Sum(d => d.DestructionLevel);
            if (Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount *= 1.3;
            }
            if (Weapons.Any(u => u.GetType().Name == "NuclearWeapon"))
            {
                totalAmount *= 1.45;
            }
            return totalAmount;
        }
    }
}
