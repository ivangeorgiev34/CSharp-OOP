using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
  public  class Tomcat : Cat
    {
        //default gender
        private const string TOMCAT_GENDER = "Male";
        public Tomcat(string name, int age) : base(name, age, TOMCAT_GENDER)
        {
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
