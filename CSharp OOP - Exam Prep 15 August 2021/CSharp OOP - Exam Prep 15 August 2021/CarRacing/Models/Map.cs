using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();
                double behaviorMultiplierRacerOne = 0;
                double behaviorMultiplierRacerTwo = 0;

                if (racerOne.RacingBehavior == "strict")
                {
                    behaviorMultiplierRacerOne = 1.2;
                }
                else if (racerOne.RacingBehavior == "aggressive")
                {
                    behaviorMultiplierRacerOne = 1.1;
                }

                if (racerTwo.RacingBehavior == "strict")
                {
                    behaviorMultiplierRacerTwo = 1.2;
                }
                else if (racerTwo.RacingBehavior == "aggressive")
                {
                    behaviorMultiplierRacerTwo = 1.1;
                }

                var firstRacerChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * behaviorMultiplierRacerOne;
                var secondRacerChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * behaviorMultiplierRacerTwo;

                if (firstRacerChanceOfWinning > secondRacerChanceOfWinning)
                {
                    
                    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
                }
                else if (firstRacerChanceOfWinning < secondRacerChanceOfWinning)
                {
                    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
                }
                return "";
            }

        }
    }
}
