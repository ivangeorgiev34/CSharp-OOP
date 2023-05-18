using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double GINGER_BREAD_PRICE = 4;
        public Gingerbread(string delicacyName ) : base(delicacyName, GINGER_BREAD_PRICE)
        {
        }
    }
}
