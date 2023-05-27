namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void Robot_ConstructorShouldWorkProperly()
        {
            Robot robot = new Robot("jake", 100);

            Assert.AreEqual("jake", robot.Name);
            Assert.AreEqual(100, robot.Battery);
            Assert.AreEqual(100, robot.MaximumBattery);
        }

        [Test]
        public void RobotManager_ConstructorShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager( 10);

            Assert.AreEqual(10, robotManager.Capacity);
        }

        [Test]
        public void RobotManager_PropertyCapacityShouldThrowExceptionWhenIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-1);
            });
        }

        [Test]
        public void RobotManager_AddMethodShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("jake", 100);
            int initialCount = robotManager.Count;
            robotManager.Add(robot);
            Assert.AreEqual(initialCount, robotManager.Count - 1);
        }

        [Test]
        public void RobotManager_AddMethodShouldThrowExceptionWhenRobotAlreadyExists()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("jake", 100);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
            });
        }

        [Test]
        public void RobotManager_AddMethodShouldThrowExceptionWhenThereIsNotEnoughCapacity()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("jake", 100);
            Robot robot2 = new Robot("john", 100);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot2);
            });
        }

        [Test]
        public void RobotManager_RemoveMethodShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("jake", 100);
            robotManager.Add(robot);
            robotManager.Remove("jake");
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManager_RemoveMethodShouldThrowExceptionWhenRobotDoesNotExist()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("jake", 100);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("random");
            });
            
        }

        [Test]
        public void RobotManager_WorkMethodShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("jake", 100);
            robotManager.Add(robot);
            robotManager.Work("jake", "work", 50);
            Assert.AreEqual(50, robot.Battery);
        }

        [Test]
        public void RobotManager_WorkMethodShouldThrowExceptionWhenRobotDoesNotExist()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("jake", 100);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("random", "work", 20);
            });

        }

        [Test]
        public void RobotManager_WorkMethodShouldThrowExceptionWhenBatteryUsageIsMoreThanCurrentRobotBattery()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("jake", 100);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("jake", "work", 200);
            });

        }

        [Test]
        public void RobotManager_ChargeMethodShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("jake", 100);
            robotManager.Add(robot);
            robotManager.Work("jake", "work", 50);
            robotManager.Charge("jake");
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void RobotManager_ChargeMethodShouldThrowExceptionWhenRobotDoesNotExist()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("jake", 100);
            robotManager.Add(robot);
            robotManager.Work("jake", "work", 50);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("random");
            });
        }
    }
}
