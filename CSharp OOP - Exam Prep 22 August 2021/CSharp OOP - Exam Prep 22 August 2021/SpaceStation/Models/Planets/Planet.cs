using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private ICollection<string> items;
        private string name;

        public Planet(string name)
        {
            this.Name = name;
            items = new List<string>();
        }

        public ICollection<string> Items
        {
            get { return items; }
            private set { items = value; }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                name = value;
            }
        }

    }
}
