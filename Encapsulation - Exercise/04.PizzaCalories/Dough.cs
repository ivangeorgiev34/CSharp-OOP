using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        public Dough(string type,string bakingTechnique,double grams)
        {
            Type = type;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }
        private string type;
        private string bakingTechnique;
        private double grams;
        private double modifier = 1;
        public double CaloriesPerGram { get { return 2; }  }
        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() == "white")
                {
                    modifier = modifier * 1.5;
                }
                else if (value.ToLower() == "wholegrain")
                {
                    modifier = modifier * 1.0;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
                type = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() == "crispy")
                {
                    modifier = modifier * 0.9;
                }
                else if (value.ToLower() == "chewy")
                {
                    modifier = modifier * 1.1;
                }
                else if (value.ToLower() == "homemade" )
                {
                    modifier = modifier * 1.0;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double Grams
        {
            get { return grams; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception($"Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }

        public double CalculateCalories()
        {
            return CaloriesPerGram * Grams * modifier;
        }
    }
}
