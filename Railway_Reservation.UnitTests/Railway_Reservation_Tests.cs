using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;

namespace Railway_Reservation.UnitTests
{
    [TestFixture]
    public class Railway_Reservation_Tests
    {
        private MethodInfo testingMethod1;
        private MethodInfo testingMethod2;
        private object SUT;

        [SetUp]
        public void Initialize()
        {
            Assembly assembly = Assembly.Load("Railway_Reservation");
            SUT = assembly.CreateInstance(assembly.GetTypes().Where(type => type.Name == "PassengerDetailVerification").FirstOrDefault()?.FullName,
                false, BindingFlags.CreateInstance, null, null, null, null);
            testingMethod1 = SUT.GetType().GetMethod("CheckPassengerId");
            testingMethod2 = SUT.GetType().GetMethod("GetTicketCost");
        }

        [Test]
        public void Check_Valid_PassengerId()
        {
            string passengerId = "VA18214L";
            Assert.AreEqual(true, testingMethod1.Invoke(SUT, new object[] { passengerId }));
        }

        [Test]
        public void Check_InValid_PassengerId()
        {
            string passengerId = "12345";
            Assert.AreEqual(false, testingMethod1.Invoke(SUT, new object[] { passengerId }));
        }

        [Test]
        public void Check_Cost_When_Age_Is_Less_Than_Five()
        {
            int age = 4;
            Assert.AreEqual(0, testingMethod2.Invoke(SUT, new object[] { age }));
        }

        [Test]
        public void Check_Cost_When_Age_Is_Five()
        {
            int age = 5;
            Assert.AreEqual(0, testingMethod2.Invoke(SUT, new object[] { age }));
        }

        [Test]
        public void Check_Cost_When_Age_Is_Between_Five_And_Sixty()
        {
            int age = 14;
            Assert.AreEqual(500, testingMethod2.Invoke(SUT, new object[] { age }));
        }

        [Test]
        public void Check_Cost_When_Age_Is_Sixty()
        {
            int age = 60;
            Assert.AreEqual(250, testingMethod2.Invoke(SUT, new object[] { age }));
        }

        [Test]
        public void Check_Cost_When_Age_Is_Greater_Than_Sixty()
        {
            int age = 64;
            Assert.AreEqual(250, testingMethod2.Invoke(SUT, new object[] { age }));
        }
    }
}
