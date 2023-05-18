using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [SetUp] 
        public void SetUp()
        {

        }

        [Test]
        public void Smartphone_ConstructorShouldWorkProperly()
        {
            Smartphone smartphone = new Smartphone("iphone10", 100);
            Assert.AreEqual("iphone10", smartphone.ModelName);
            Assert.AreEqual(100, smartphone.MaximumBatteryCharge);
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Shop_ConstructorShouldWorkProperly()
        {
            Shop shop = new Shop(100);
            Assert.AreEqual(100, shop.Capacity);
        }

        [Test]
        public void Shop_PropertyCapacityShouldThrowExceptionWhenIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-1);
            });
        }

        [Test]
        public void Shop_MethodAddShouldWorkProperly()
        {
            Shop shop = new Shop(100);
            int initialCount = shop.Count;
            shop.Add(new Smartphone("iphone", 100));
            Assert.AreEqual(initialCount+1, shop.Count);
        }

        [Test]
        public void Shop_MethodAddShouldThrowExceptionWhenPhoneAlreadyExists()
        {
            Shop shop = new Shop(100);
            shop.Add(new Smartphone("iphone", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("iphone", 100));
            });
        }

        [Test]
        public void Shop_MethodAddShouldThrowExceptionWhenCountEqualsShopCapacity()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("iphone", 100));
            shop.Add(new Smartphone("samsung", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("huawei", 100));
            });
        }

        [Test]
        public void Shop_MethodRemoveShouldWorkProperly()
        {
            Shop shop = new Shop(100);
            int initialCount = shop.Count;
            shop.Add(new Smartphone("iphone", 100));
            shop.Remove("iphone");
            Assert.AreEqual(initialCount , shop.Count);
        }

        [Test]
        public void Shop_MethodRemoveShouldThrowExceptionWhenCannotFindPhoneWithSuchName()
        {
            Shop shop = new Shop(100);
            shop.Add(new Smartphone("iphone", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("kgwej");
            });
        }

        [Test]
        public void Shop_MethodTestPhoneShouldWorkProperly()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("iphone", 100);
            shop.Add(phone);
            shop.TestPhone("iphone", 50);
            Assert.AreEqual(50,phone.CurrentBateryCharge);
        }

        [Test]
        public void Shop_MethodTestPhoneShouldThrowExceptionWhenCannotFindSuchPhone()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("iphone", 100);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("sg", 50);
            });
        }

        [Test]
        public void Shop_MethodTestPhoneShouldThrowExceptionWhenBatteryIsTooLow()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("iphone", 100);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("iphone", 120);
            });
        }

        [Test]
        public void Shop_MethodChargePhoneShouldWorkProperly()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("iphone", 100);
            shop.Add(phone);
            shop.TestPhone("iphone", 50);
            shop.ChargePhone("iphone");
            Assert.AreEqual(phone.CurrentBateryCharge, phone.MaximumBatteryCharge);
        }

        [Test]
        public void Shop_MethodChargePhoneShouldThrowExceptionWhenCannotFindSuchPhone()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("iphone", 100);
            shop.Add(phone);
            shop.TestPhone("iphone", 50);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("grewew");
            });
        }
    }
}