using Gym.Core.Contracts;
using Gym.Models;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipments.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            IAthlete athlete = null;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            if (athlete.GetType().Name == "Boxer" && gym.GetType().Name == "BoxingGym")
            {
                gym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
            else if (athlete.GetType().Name == "Weightlifter" && gym.GetType().Name == "WeightliftingGym")
            {
                gym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
            else
            {
                return "The gym is not appropriate.";
            }
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
            IEquipment equipmentToAdd = null;
            if (equipmentType == "BoxingGloves")
            {
                equipmentToAdd = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipmentToAdd = new Kettlebell();
            }
            equipment.Add(equipmentToAdd);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            IGym gym = null;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            gyms.Add(gym);

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if ( !equipment.Models.Any(e => e.GetType().Name == equipmentType))
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            IEquipment equipmentToAdd = null;

            if (equipmentType == "BoxingGloves")
            {
                equipmentToAdd = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipmentToAdd = new Kettlebell();
            }

            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
            gym.AddEquipment(equipmentToAdd);
            equipment.Remove(equipment.FindByType(equipmentType));

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
