using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private int numberOfPlayers;
        private string name;
        private int rating;
        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
            
        }
        private List<Player> players;

        public List<Player> Players
        {
            get { return players; }
            private set { players = value; }
        }

        public int NumberOfPlayers
        {
            get { return numberOfPlayers; }
            private set { numberOfPlayers = value; }
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
        public int Rating
        {
            get { return rating; }
            private set
            {
                int sum = 0;
                int count = 0;
                for (int i = 0; i < Players.Count; i++)
                {
                    int sumOfStatsForCurrentPlayer = (Players[i].Endurance + Players[i].Sprint + Players[i].Dribble + Players[i].Passing + Players[i].Shooting) / 5;
                    sum = sum + sumOfStatsForCurrentPlayer;
                    count++;
                }
                value = sum / count;
                rating = value;
            }
        }
        public void AddPlayer(Player player)
        {
            Players.Add(player);
            NumberOfPlayers++;
        }
        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
            NumberOfPlayers--;
        }
        public int TeamRating()
        {
            if (Players.Count==0)
            {
                return 0;
            }
            return (int)Math.Round(Players.Average(x => x.OverallRating));
        }
    }
}
