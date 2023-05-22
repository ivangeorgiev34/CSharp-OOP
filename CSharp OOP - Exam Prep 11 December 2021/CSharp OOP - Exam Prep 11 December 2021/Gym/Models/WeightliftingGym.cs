using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models
{
    public class WeightliftingGym : Gym
    {
        private const int WEIGHT_LIFTING_GYM_CAPACITY = 20;
        public WeightliftingGym(string name) : base(name, WEIGHT_LIFTING_GYM_CAPACITY)
        {
        }
    }
}
