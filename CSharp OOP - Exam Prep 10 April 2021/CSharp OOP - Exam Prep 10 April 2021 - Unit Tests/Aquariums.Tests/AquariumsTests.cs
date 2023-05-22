namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]

    public class AquariumsTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Fish_ConstructorShouldSetValuesProperly()
        {
            string expectedName = "abc";
            bool expectedAvailability = true;
            Fish fish = new Fish(expectedName);

            Assert.AreEqual(expectedName, fish.Name);
            Assert.AreEqual(expectedAvailability, fish.Available);
        }

        [Test]
        public void Aquarium_ConstructorShouldSetValuesProperly()
        {
            Aquarium aquarium = new Aquarium("abc", 10);

            Assert.AreEqual("abc", aquarium.Name);
            Assert.AreEqual(10, aquarium.Capacity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Aquarium_PropertyNameShouldThrowExceptionWhenIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 10);
            });
        }

        [Test]
        public void Aquarium_PropertyCapacityShouldThrowExceptionWhenIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("abc", -1);
            });
        }

        [Test]
        public void Aquarium_MethodAddShouldIncreaseCountAndAddFish()
        {
            Fish fish = new Fish("abcd");
            Aquarium aquarium = new Aquarium("abc", 10);
            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void Aquarium_MethodAddShouldThrowsExceptionWhenCapacityEqualsAquariumCount()
        {
            Fish fish = new Fish("abcd");
            Aquarium aquarium = new Aquarium("abc", 1);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
        }

        [Test]
        public void Aquarium_MethodRemoveShouldDecreaseCountAndRemoveFish()
        {
            Fish fish = new Fish("abcd");
            Aquarium aquarium = new Aquarium("abc", 10);
            aquarium.Add(fish);
            aquarium.RemoveFish("abcd");

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void Aquarium_MethodRemoveShouldThrowExceptionWhenFishWithSuchNameDoesNotExist()
        {
            Fish fish = new Fish("abcd");
            Aquarium aquarium = new Aquarium("abc", 10);
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("random");
            });
        }

        [Test]
        public void Aquarium_MethodSellFishShouldSetFishPropertyAvailableToFalse()
        {
            Fish fish = new Fish("abcd");
            Aquarium aquarium = new Aquarium("abc", 10);
            aquarium.Add(fish);
            aquarium.SellFish("abcd");

            Assert.AreEqual(false, aquarium.SellFish("abcd").Available);
        }

        [Test]
        public void Aquarium_MethodSellFishShouldThrowExceptionWhenFishWithSuchNameDoesNotExist()
        {
            Fish fish = new Fish("abcd");
            Aquarium aquarium = new Aquarium("abc", 10);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("random");
            });
        }

        [Test]
        public void Aquarium_MethodReportShouldReturnCorrectString()
        {
            Fish fish = new Fish("abcd");
            Fish fish2 = new Fish("abcde");
            Aquarium aquarium = new Aquarium("abc", 10);
            aquarium.Add(fish);
            aquarium.Add(fish2);

            Assert.AreEqual("Fish available at abc: abcd, abcde",aquarium.Report());
        }
    }
}
