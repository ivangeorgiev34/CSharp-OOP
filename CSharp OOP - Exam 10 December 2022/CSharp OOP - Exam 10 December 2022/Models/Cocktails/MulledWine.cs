using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        //CHECK FOR ERRORS HERE
        private const double MULLED_WINE_PRICE = 13.50;
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, MULLED_WINE_PRICE)
        {
        }
    }
}
