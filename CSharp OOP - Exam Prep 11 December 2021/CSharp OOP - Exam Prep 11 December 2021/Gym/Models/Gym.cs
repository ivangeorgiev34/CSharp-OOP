using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipments.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.Name= name;
            this.Capacity= capacity;
            this.equipment= new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value; 
            }
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public double EquipmentWeight => Equipment.Sum(w => w.Weight);

        public ICollection<IEquipment> Equipment
        {
            get { return equipment; }           
        }

        public ICollection<IAthlete> Athletes
        {
            get { return athletes; }
        }


        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == Athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            this.athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
           this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (Athletes.Count == 0)
            {
                sb.AppendLine($"Athletes: No athletes");
            }
            else
            {
                sb.AppendLine($"Athletes: {string.Join(", ", this.Athletes.Select(x=>x.FullName))}");
            }
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
