using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        private const double SPACEFORCE_COST = 11;
        public SpaceForces( ) : base(SPACEFORCE_COST)
        {
        }
    }
}
