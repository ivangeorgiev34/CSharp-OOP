using CarRacing.Core.Contracts;
using CarRacing.Models;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException("Invalid car type!");
            }
            ICar car = null;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (cars.FindBy(carVIN) == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            else if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException("Invalid racer type!");
            }
            IRacer racer = null;
            var car = cars.FindBy(carVIN);
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            racers.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var firstRacer = racers.FindBy(racerOneUsername);
            var secondRacer = racers.FindBy(racerTwoUsername);

            if (firstRacer == null)
            {
                return $"Racer {racerOneUsername} cannot be found!";
            }
            else if (secondRacer == null)
            {
                return $"Racer {racerTwoUsername} cannot be found!";
            }

            return map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var orderRacers = racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username);
            foreach (var racer in orderRacers)
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
//AddCar SuperCar BMW M8 JN1HJ01P0MT518872 617
//AddRacer ProfessionalRacer Atanas JN1HJ01P0MT518872
//AddCar SuperCar Audi RS6 5N1AN08W86C526409 591
//AddRacer StreetRacer Shopoff 5N1AN08W86C526409
//Report
    }
}
