using NUnit.Framework;
using System;

namespace AxeTesting
{
    public class DummyTests
    {
        private Dummy dummy;
        [SetUp]
        public void Setup()
        {
            dummy = new Dummy(10,10);
        }
        [Test]
        public void Test_ThrowExceptionWhenHealthIsBelowZero()
        {
            for (int i = 0; i < 2; i++)
            {
                dummy.TakeAttack(5);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(6);
            });
        }
        [Test]
        public void Test_ThrowExceptionWhenHealthIsZero()
        {
            for (int i = 0; i < 2; i++)
            {
                dummy.TakeAttack(5);
            }
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(5);
            });
        }

        [Test]
        public void Test_ThrowExceptionWhenTargetIsNotDead()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
        [Test]
        public void Test_DoNotThrowExceptionWhenTargetIsDead()
        {
            for (int i = 0; i < 2; i++)
            {
                dummy.TakeAttack(5);
            }
            Assert.DoesNotThrow(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}
