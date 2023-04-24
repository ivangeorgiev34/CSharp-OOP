using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //            Team; Arsenal
            // Add; Arsenal; Kieran_Gibbs; 75; 85; 84; 92; 67
            //Add; Arsenal; Aaron_Ramsey; 95; 82; 82; 89; 68
            //Remove; Arsenal; Aaron_Ramsey
            //  Rating; Arsenal
            //   END

            List<Team> teams = new List<Team>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Team")
                {
                    teams.Add(new Team(tokens[1]));
                }
                else if (tokens[0] == "Add")
                {
                    if (teams.Exists(x => x.Name == tokens[1]))
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == tokens[1]);
                        Player player = new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                        if (!string.IsNullOrEmpty(player.Name) && !string.IsNullOrWhiteSpace(player.Name) && player.Endurance != 0 && player.Dribble != 0 && player.Passing != 0 && player.Shooting != 0 && player.Sprint != 0)
                        {
                            team.AddPlayer(player);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    Team team = teams.FirstOrDefault(x => x.Name == tokens[1]);
                    if (team.Players.Any(x => x.Name == tokens[2]))
                    {
                        Player player = team.Players.FirstOrDefault(x => x.Name == tokens[2]);
                        team.RemovePlayer(player);
                    }
                    else
                    {
                        Console.WriteLine($"Player {tokens[2]} is not in {team.Name} team.");
                    }
                }
                else if (tokens[0] == "Rating")
                {
                    if (teams.Exists(x => x.Name == tokens[1]))
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == tokens[1]);
                        Console.WriteLine($"{tokens[1]} - {team.TeamRating()}");
                    }
                    else
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                    }
                }
                command = Console.ReadLine();
            }



        }
    }
}
