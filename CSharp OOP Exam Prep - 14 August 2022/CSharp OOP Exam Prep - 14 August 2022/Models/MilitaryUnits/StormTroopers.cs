using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class StormTroopers : MilitaryUnit
    {
        private const double STORMTROOPER_COST = 2.5;
        public StormTroopers( ) : base(STORMTROOPER_COST)
        {
        }
    }
}
