using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            OverallRating = Endurance + Sprint + Dribble + Passing + Shooting;
        }
        private int overallRating;

        public int OverallRating
        {
            get { return overallRating; }
            private set
            {
                value = (int)Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);
                overallRating = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("A name should not be empty.");
                }
                else
                {
                    name = value;
                }

            }
        }
        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Endurance should be between 0 and 100.");
                }
                else
                {
                    endurance = value;
                }

            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Sprint should be between 0 and 100.");
                }
                else
                {
                    sprint = value;
                }

            }
        }
        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Dribble should be between 0 and 100.");
                }
                else
                {
                    dribble = value;
                }

            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Passing should be between 0 and 100.");
                }
                else
                {
                    passing = value;
                }

            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Shooting should be between 0 and 100.");
                }
                else
                {
                    shooting = value;
                }

            }
        }
    }
}
