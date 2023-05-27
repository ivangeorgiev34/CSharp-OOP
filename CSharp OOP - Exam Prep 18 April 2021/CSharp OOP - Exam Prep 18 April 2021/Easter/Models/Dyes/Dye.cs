﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Easter.Models.Dyes.Contracts
{
    public class Dye : IDye
    {
        private int power;
        public Dye(int power)
        {
            this.Power= power;
        }  

        public int Power
        {
            get { return power; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                power = value;
            }
        }


        public bool IsFinished()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            this.Power -= 10;
        }
    }
}
