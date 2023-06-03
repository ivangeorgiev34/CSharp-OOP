using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [SetUp]
            public void SetUp()
            {

            }
            [Test]
            public void Weapon_ConstructorShouldWorkProperly()
            {
                Weapon weapon = new Weapon("a", 20.3, 3);
                Assert.AreEqual("a", weapon.Name);
                Assert.AreEqual(20.3, weapon.Price);
                Assert.AreEqual(3, weapon.DestructionLevel);
            }
            [Test]
            public void Weapon_PropertyPriceShouldThrowExceptionWhenIsBelowZero()
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("a", -1, 3);
                });
            }

            [Test]
            public void Weapon_MethodIncreaseDestructionLevelWorksProperly()
            {

                Weapon weapon = new Weapon("a", 20.2, 3);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(4, weapon.DestructionLevel);
            }

            [Test]
            public void Weapon_PropertyIsNuclearWorksProperly()
            {
                Weapon weapon = new Weapon("a", 20.2, 9);
                Assert.AreEqual(false, weapon.IsNuclear);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(true, weapon.IsNuclear);
            }

            [Test]
            public void Planet_ConstructorShouldWorkProperly()
            {
                Planet planet = new Planet("a", 200.3);
                Assert.AreEqual("a", planet.Name);
                Assert.AreEqual(200.3, planet.Budget);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void Planet_PropertyNameShouldThrowExceptionWhenIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 200.3);
                });
            }

            [Test]
            public void Planet_PropertyBudgetShouldThrowExceptionWhenIsBelowZero()
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("a", -1);
                });
            }

            [Test]
            public void Planet_PropertyMilitaryPowerRatioShouldWorkProperly()
            {
                Planet planet = new Planet("planet", 200.3);
                planet.AddWeapon(new Weapon("a", 20.2, 9));
                planet.AddWeapon(new Weapon("b", 20.2, 9));
                Assert.AreEqual(18, planet.MilitaryPowerRatio);
            }

            [Test]
            public void Planet_MethodProfitWorksProperly()
            {
                Planet planet = new Planet("planet", 200.3);
                planet.Profit(20);
                Assert.AreEqual(220.3, planet.Budget);
            }

            [Test]
            public void Planet_MethodSpendFundsWorksProperly()
            {
                Planet planet = new Planet("planet", 200);
                planet.SpendFunds(100);
                Assert.AreEqual(100, planet.Budget);
            }

            [Test]
            public void Planet_MethodSpendFundsShouldThrowExceptionWhenAmountToRemoveIsBiggerThanBudget()
            {
                Planet planet = new Planet("planet", 200);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(300);
                });
            }

            [Test]
            public void Planet_MethodAddWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("planet", 200);
                Weapon weapon = new Weapon("eg", 200, 3);
                planet.AddWeapon(weapon);
                Assert.AreSame(weapon, planet.Weapons.FirstOrDefault(x => x.Name == "eg"));
            }

            [Test]
            public void Planet_MethodAddWeaponShouldThrowExceptionWhenExistsAlreadyInWeapons()
            {
                Planet planet = new Planet("planet", 200);
                Weapon weapon = new Weapon("eg", 200, 3);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                });
            }

            [Test]
            public void Planet_MethodRemoveWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("planet", 200);
                Weapon weapon = new Weapon("eg", 200, 3);
                planet.AddWeapon(weapon);
                planet.RemoveWeapon("eg");
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void Planet_MethodUpgradeWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("planet", 200);
                Weapon weapon = new Weapon("eg", 200, 3);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("eg");
                Assert.AreEqual(4, planet.Weapons.FirstOrDefault(w => w.Name == "eg").DestructionLevel);
            }

            [Test]
            public void Planet_MethodUpgradeWeaponShouldThrowsExceptionWhenWeaponDoesNotExistInWeapons()
            {
                Planet planet = new Planet("planet", 200);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("a");
                });
            }

            [Test]
            public void Planet_MethodDestructOpponentShouldWorkProperly()
            {
                Planet planet = new Planet("planet", 200);
                Weapon weapon = new Weapon("eg", 200, 100);
                planet.AddWeapon(weapon);
                Planet planet2 = new Planet("rh", 200);
                Weapon weapon2 = new Weapon("e", 200, 1);
                planet2.AddWeapon(weapon2);
                string expectedOutput = planet.DestructOpponent(planet2);

                Assert.AreEqual(expectedOutput, planet.DestructOpponent(planet2));

            }

            [Test]
            public void Planet_MethodShouldThrowExceptionWhenOpponentMilitaryPowerEqualsThisPlanetMilitaryPower()
            {
                Planet planet = new Planet("planet", 200);
                Weapon weapon = new Weapon("eg", 200, 100);
                planet.AddWeapon(weapon);
                Planet planet2 = new Planet("rh", 200);
                Weapon weapon2 = new Weapon("e", 200, 100);
                planet2.AddWeapon(weapon2);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet2);
                });

            }

            [Test]
            public void Planet_MethodShouldThrowExceptionWhenOpponentMilitaryPowerIsBiggerThisPlanetMilitaryPower()
            {
                Planet planet = new Planet("planet", 200);
                Weapon weapon = new Weapon("eg", 200, 100);
                planet.AddWeapon(weapon);
                Planet planet2 = new Planet("rh", 200);
                Weapon weapon2 = new Weapon("e", 200, 100);
                planet2.AddWeapon(weapon2);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet2);
                });

            }
        }
    }

}
