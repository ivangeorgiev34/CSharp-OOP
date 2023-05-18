using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        //CHECK FOR ERRORS HERE
        private const double HIBERNATION_PRICE = 10.50;
        public Hibernation(string cocktailName, string size) : base(cocktailName, size, HIBERNATION_PRICE)
        {
        }
    }
}
