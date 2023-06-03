using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private ICollection<IMilitaryUnit> units;
        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)units;

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            if (units.Any(u => u.GetType().Name == name))
            {
                return units.FirstOrDefault(u => u.GetType().Name == name);
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            if (units.Any(u => u.GetType().Name == name))
            {
                units.Remove(units.FirstOrDefault(u => u.GetType().Name == name));
                return true;
            }
            return false;
        }
    }
}
