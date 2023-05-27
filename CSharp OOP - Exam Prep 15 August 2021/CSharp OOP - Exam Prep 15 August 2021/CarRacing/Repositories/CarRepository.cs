﻿using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> cars;
        public CarRepository()
        {
            cars = new List<ICar>();    
        }
        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)cars;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            cars.Add(model);
        }

        public ICar FindBy(string property)
        {
            return cars.FirstOrDefault(c => c.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }
    }
}
