using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Models.Contracts.Race;
using Formula1.Models.FormulaOneCars;
using Formula1.Models.Pilot;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilots;
        private FormulaOneCarRepository formulaOneCars;
        private RaceRepository races;
        public Controller()
        {
            pilots = new PilotRepository();
            formulaOneCars = new FormulaOneCarRepository();
            races = new RaceRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilots.Models.Any(p => p.FullName == pilotName))
            {
                if (pilots.Models.FirstOrDefault(p => p.FullName == pilotName).Car != null)
                {
                    throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
                }
            }
            else
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }
            if (!formulaOneCars.Models.Any(c => c.Model == carModel))
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }
            IFormulaOneCar carToAddToPilot = formulaOneCars.Models.FirstOrDefault(c => c.Model == carModel);
            IPilot pilotToAddCarTo = pilots.Models.FirstOrDefault(p => p.FullName == pilotName);
            pilotToAddCarTo.AddCar(carToAddToPilot);

            return $"Pilot {pilotName} will drive a {carToAddToPilot.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (!races.Models.Any(r => r.RaceName == raceName))
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (pilots.Models.Any(p => p.FullName == pilotFullName))
            {
                

                if (pilots.Models.FirstOrDefault(p => p.FullName == pilotFullName).CanRace == false)
                {
                    throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
                }
                else if (pilots.Models.FirstOrDefault(p => p.FullName == pilotFullName).Car == null)
                {
                    throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
                }
                else if (races.Models.FirstOrDefault(r => r.RaceName == raceName).Pilots.Any(p => p.FullName == pilotFullName)) 
                {
                    throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
                }
                else
                {
                    IPilot pilotToAdd = pilots.Models.FirstOrDefault(p => p.FullName == pilotFullName);
                    IRace raceToAddPilotTo = races.Models.FirstOrDefault(r => r.RaceName == raceName);
                    raceToAddPilotTo.AddPilot(pilotToAdd);

                    return $"Pilot {pilotFullName} is added to the {raceName} race.";
                }
            }
            else
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (formulaOneCars.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }
            else if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            IFormulaOneCar car = null;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            formulaOneCars.Add(car);

            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (pilots.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            IPilot pilotToAdd = new Pilot(fullName);
            pilots.Add(pilotToAdd);

            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (races.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }
            IRace raceToAdd = new Race(raceName, numberOfLaps);
            races.Add(raceToAdd);

            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            var orderedPilots = pilots.Models.OrderByDescending(p => p.NumberOfWins);
            foreach (var pilot in orderedPilots)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            var executedRaces = races.Models.Where(r => r.TookPlace == true);
            foreach (var race in executedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if (!races.Models.Any(r => r.RaceName == raceName))
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            else if (races.Models.FirstOrDefault(r => r.RaceName == raceName).Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            else if (races.Models.FirstOrDefault(r => r.RaceName == raceName).TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }
            races.Models.FirstOrDefault(r => r.RaceName == raceName).TookPlace = true;
            var orderedRace = races.Models.FirstOrDefault(r => r.RaceName == raceName).Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(races.Models.FirstOrDefault(r => r.RaceName == raceName).NumberOfLaps)).ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < orderedRace.Count; i++)
            {
                if (i == 0)
                {
                    orderedRace[i].WinRace();
                    sb.AppendLine($"Pilot {orderedRace[i].FullName} wins the {raceName} race.");
                }
                else if (i == 1)
                {
                    sb.AppendLine($"Pilot {orderedRace[i].FullName} is second in the {raceName} race.");
                }
                else if (i == 2)
                {
                    sb.AppendLine($"Pilot {orderedRace[i].FullName} is third in the {raceName} race.");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
