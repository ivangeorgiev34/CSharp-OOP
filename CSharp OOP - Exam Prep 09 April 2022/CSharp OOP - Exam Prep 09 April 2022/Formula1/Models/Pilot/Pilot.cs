using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Pilot
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;
        public Pilot(string fullName)
        {
            this.FullName = fullName;
            
        }
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                fullName = value;
            }
        }
        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                car = value;
            }
        }
        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }
        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }


        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
