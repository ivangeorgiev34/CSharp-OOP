namespace Presents.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Present_ConstructorShouldWorkProperly()
        {
            Present present = new Present("abc", 10);
            Assert.AreEqual("abc", present.Name);
            Assert.AreEqual(10, present.Magic);
        }

        [Test]
        public void Bag_ConstructorShouldWorkProperly()
        {
            Bag bag = new Bag();
            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void Bag_MethodCreateShouldWorkProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("abc", 10);
            Assert.AreEqual("Successfully added present abc.", bag.Create(present));
            Assert.AreEqual(1, bag.GetPresents().Count);
        }

        [Test]
        public void Bag_MethodCreateShouldThrowExceptionWhenPresentIsNull()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);   
            });
        }

        [Test]
        public void Bag_MethodCreateShouldThrowExceptionWhenPresentAlreadyExists()
        {
            Bag bag = new Bag();
            Present present = new Present("abc", 10);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Bag_MethodRemoveShouldWorkProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("abc", 10);
            bag.Create(present);

            Assert.AreEqual(true, bag.Remove(present));
            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void Bag_MethodRemoveShouldReturnFalseWhenCannotFindPresent()
        {
            Bag bag = new Bag();
            Present present = new Present("abc", 10);
            bag.Create(present);

            Assert.AreEqual(false, bag.Remove(null));
        }

        [Test]
        public void Bag_MethodGetPresentWithLeastMagicShouldWorkProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("abc", 10);
            Present present2 = new Present("abcd", 20);
            bag.Create(present);
            bag.Create(present2);

            Assert.AreSame(present, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void Bag_MethodGetPresentShouldWorkProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("abc", 10);
            bag.Create(present);

            Assert.AreSame(present, bag.GetPresent("abc"));
        }
    }
}
