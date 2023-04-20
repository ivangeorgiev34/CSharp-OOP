using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
   public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
