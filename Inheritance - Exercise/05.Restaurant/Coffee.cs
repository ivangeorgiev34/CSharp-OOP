﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal COFFEE_PRICE = 3.50M;
        private const double COFFEE_MILLILITERS = 50D;

        public Coffee(string name, double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {
            Caffeine = caffeine;

        }

        public double Caffeine { get; set; }



    }
}
