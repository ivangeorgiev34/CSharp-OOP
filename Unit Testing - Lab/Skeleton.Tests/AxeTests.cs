using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        [SetUp]
        public void Setup()
        {
            axe = new Axe(10, 10);
        }

        [Test]
        public void Test_DurabilityPointsEqualToZero()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    axe.Attack(new Dummy(100, 100));
                }
                //axe.DurabilityPoints = 0;
                axe.Attack(new Dummy(100, 100));
            });
        }
        [Test]
        public void Test_DurabilityPointsBelowZero()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 11; i++)
                {
                    axe.Attack(new Dummy(100, 100));
                }
                //axe.DurabilityPoints = 0;
                axe.Attack(new Dummy(100, 100));
            });
        }
    }
}