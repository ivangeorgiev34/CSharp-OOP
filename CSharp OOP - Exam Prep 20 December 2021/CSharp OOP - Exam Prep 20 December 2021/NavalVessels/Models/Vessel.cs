using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                name = value;
            }
        }
        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armorThickness; }
             set { armorThickness = value; }
        }
        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            protected set { mainWeaponCaliber = value; }
        }
        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }
        public ICollection<string> Targets
        {
            get { return targets; }
        }


        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            double result = target.ArmorThickness - this.MainWeaponCaliber;
            if (result <= 0)
            {
                target.ArmorThickness = 0;
            }
            else
            {
                target.ArmorThickness = result;
            }

            this.targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            if (this.GetType().Name == "Battleship")
            {
                this.ArmorThickness = 300;
            }
            else if (this.GetType().Name == "Submarine")
            {
                this.ArmorThickness = 200;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else if (this.Targets.Count > 0)
            {
                sb.AppendLine($" *Targets: {string.Join(", ", Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
