using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> planets;
        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)planets;

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            if (planets.Any((p => p.GetType().Name == name)))
            {
                return planets.FirstOrDefault(p => p.GetType().Name == name);
            }
            return null;
        }
        public bool RemoveItem(string name)
        {
            if (planets.Any(p => p.Name == name))
            {
                planets.Remove(planets.FirstOrDefault(p => p.Name == name));
                return true;
            }
            return false;
        }
    }
}
