using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }
        [Test]
        public void Athlete_ConstructorShouldWorkProperly()
        {
            Athlete athlete = new Athlete("john");

            Assert.AreEqual("john", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        public void Gym_ConstructorShouldWorkProperly()
        {
            Gym gym = new Gym("gym",5);

            Assert.AreEqual("gym", gym.Name);
            Assert.AreEqual(5, gym.Capacity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Gym_PropertyNameShouldThrowExceptionWhenIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 5);
            });
        }

        [Test]
        public void Gym_PropertyCapacityShouldThrowExceptionWhenIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("gym", -2);
            });
        }

        [Test]
        public void Gym_MethodAddAthleteShouldWorkProperly()
        {
            Athlete athlete = new Athlete("john");
            Gym gym = new Gym("gym", 5);
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Gym_MethodAddAthleteShouldWorkThrowExceptionWhenGymIsFull()
        {
            Athlete athlete = new Athlete("john");
            Gym gym = new Gym("gym", 1);
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete);
            });
        }

        [Test]
        public void Gym_MethodRemoveAthleteShouldWorkProperly()
        {
            Athlete athlete = new Athlete("john");
            Gym gym = new Gym("gym", 5);
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("john");

            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void Gym_MethodRemoveAthleteShouldThrowExceptionWhenCannotFindAthlete()
        {
            Athlete athlete = new Athlete("john");
            Gym gym = new Gym("gym", 5);
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("random");
            });
        }

        [Test]
        public void Gym_MethodInjureAthleteShouldWorkProperly()
        {
            Athlete athlete = new Athlete("john");
            Gym gym = new Gym("gym", 5);
            gym.AddAthlete(athlete);
            gym.InjureAthlete("john");

            Assert.AreEqual(true, gym.InjureAthlete("john").IsInjured);
        }

        [Test]
        public void Gym_MethodInjureAthleteShouldThrowExceptionWhenCannotFindAthlete()
        {
            Athlete athlete = new Athlete("john");
            Gym gym = new Gym("gym", 5);
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("random");
            });
        }

        [Test]
        public void Gym_MethodReportShouldWorkProperly()
        {
            Athlete athlete = new Athlete("john");
            Gym gym = new Gym("gym", 5);
            gym.AddAthlete(athlete);
            string expectedText = $"Active athletes at gym: john";
            Assert.AreEqual(expectedText, gym.Report());
        }
    }
}
