using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
  public  class Bird : Animal
    {
        public Bird(string name,double weight ,double wingSize) : base(name,weight)
        {
            this.WingSize = wingSize;
        }
        public double WingSize { get; protected set; }
        
    }
}
