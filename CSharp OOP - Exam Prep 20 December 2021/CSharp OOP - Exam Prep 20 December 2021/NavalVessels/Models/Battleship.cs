using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship,IVessel
    {
        private const double BATTLESHIP_ARMOR_THICKNESS = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, BATTLESHIP_ARMOR_THICKNESS)
        {
        }
        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }


        public void ToggleSonarMode()
        {
            if (this.SonarMode == true)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                SonarMode = false;
            }
            else if (this.SonarMode == false)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                SonarMode = true;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.SonarMode == true)
            {
                sb.AppendLine(" *Sonar mode: ON");
            }
            else if (this.SonarMode == false)
            {
                sb.AppendLine(" *Sonar mode: OFF");
            }
            return base.ToString().TrimEnd() + Environment.NewLine + sb.ToString().TrimEnd();
        }
    }
}
