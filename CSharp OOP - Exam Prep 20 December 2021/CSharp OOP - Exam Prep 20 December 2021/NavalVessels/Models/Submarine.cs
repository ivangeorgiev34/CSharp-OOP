using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine,IVessel
    {
        private const double SUBMARINE_ARMOR_THICKNESS = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, SUBMARINE_ARMOR_THICKNESS)
        {
        }
        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }
        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == true)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
                SubmergeMode = false;
            }
            else if (this.SubmergeMode == false)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                SubmergeMode = true;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.SubmergeMode == true)
            {
                sb.AppendLine(" *Submerge mode: ON");
            }
            else if (this.SubmergeMode == false)
            {
                sb.AppendLine(" *Submerge mode: OFF");
            }
            return base.ToString().TrimEnd() + Environment.NewLine + sb.ToString().TrimEnd();
        }
    }
}
