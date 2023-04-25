using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public int Battery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public string Start()
        {
            return "";
        }

        public string Stop()
        {
            return "";
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
