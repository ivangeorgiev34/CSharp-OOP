using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.Any(c => c.FullName == selectedCaptainName))
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            else if (!vessels.Models.Any(v => v.Name == selectedVesselName))
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            else if (vessels.Models.FirstOrDefault(v => v.Name == selectedVesselName).Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            captains.FirstOrDefault(c => c.FullName == selectedCaptainName).AddVessel(vessels.Models.FirstOrDefault(v => v.Name == selectedVesselName));
            vessels.Models.FirstOrDefault(v => v.Name == selectedVesselName).Captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = vessels.Models.FirstOrDefault(v => v.Name == attackingVesselName);
            var defender = vessels.Models.FirstOrDefault(v => v.Name == defendingVesselName);

            if (attacker == null)
            { 
                return $"Vessel {attackingVesselName} could not be found.";
            }
            else if (defender == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            else if (attacker.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            else if (defender.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defender.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            return captains.FirstOrDefault(c => c.FullName == captainFullName).Report().TrimEnd();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(c => c.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            }
            captains.Add(new Captain(fullName));

            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            
            if (vessels.Models.Any(v => v.Name == name))
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }
            else if (vesselType != "Submarine" && vesselType != "Battleship")
            {
                return "Invalid vessel type.";
            }
            IVessel vessel = null;
            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            vessels.Add(vessel);

            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            if (!vessels.Models.Any(v=>v.Name == vesselName))
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessels.Models.FirstOrDefault(v => v.Name == vesselName).RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            if (!vessels.Models.Any(v => v.Name == vesselName))
            {
                return $"Vessel {vesselName} could not be found.";
            }
            var vessel = vessels.Models.FirstOrDefault(v => v.Name == vesselName);
            if (vessel.GetType().Name == "Battleship")
            {
                (vessel as Battleship).ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                (vessel as Submarine).ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
        }

        public string VesselReport(string vesselName)
        {
            return vessels.Models.FirstOrDefault(v => v.Name == vesselName).ToString().TrimEnd();
        }
    }
}
