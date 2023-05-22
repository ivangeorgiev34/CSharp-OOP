﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models
{
    public class BoxingGym : Gym
    {
        private const int BOXING_GYM_CAPACITY = 15;
        public BoxingGym(string name ) : base(name, BOXING_GYM_CAPACITY)
        {
        }
    }
}
