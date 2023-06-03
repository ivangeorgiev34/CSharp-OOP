using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)weapons;

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            if (weapons.Any(w => w.GetType().Name == name))
            {
                return weapons.FirstOrDefault(w => w.GetType().Name == name);
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            if (weapons.Any(w=>w.GetType().Name == name))
            {
                weapons.Remove(weapons.FirstOrDefault(w => w.GetType().Name == name));
                return true;
            }
            return false;
        }
    }
}
