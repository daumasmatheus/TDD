using Application.App4;
using NUnit.Framework;
using System;

namespace Application_Tests.App4_Tests
{
    [TestFixture]
    public class JobEntranceRegistrationTests
    {
        private Employee _emp;
        private EntranceRegistration _registrator;

        [SetUp]
        public void SetupTests()
        {
            _registrator = new EntranceRegistration();
            _emp = new Employee();
        }

        [TearDown]
        public void TearDown()
        {
            _registrator = null;
        }


        [Test]
        public void RegisterEntrance_ShouldRegisterTheDateAndTimeOfTheEmployeeEntrance()
        {
            _registrator.RegisterEntrance(_emp);

            DateTime expectedEntrance = DateTime.Now;

            Assert.That(_emp.Entrance, Is.EqualTo(expectedEntrance).Within(TimeSpan.FromHours(3.0)));
        }

        [Test]
        public void RegisterInterval_ShouldRegisterTheDateAndTimeOfTheEmployeeInterval()
        {
            _registrator.RegisterInterval(_emp);

            DateTime expectedInterval = DateTime.Now;

            Assert.That(_emp.Interval, Is.EqualTo(expectedInterval).Within(TimeSpan.FromHours(3.0)));
        }

        [Test]
        public void RegisterIntervalEnd_ShouldRegisterTheDateAndTimeOfTheEmployeeIntervalEnding()
        {
            _registrator.RegisterIntervalEnd(_emp);

            DateTime expectedIntervalEnd = DateTime.Now;

            Assert.That(_emp.IntervalEnd, Is.EqualTo(expectedIntervalEnd).Within(TimeSpan.FromHours(3.0)));
        }

        [Test]
        public void RegisterDeparture_ShoudRegisterTheDateAndTimeOfTheEmployeeDeparture()
        {
            _registrator.RegisterDeparture(_emp);

            DateTime expectedDeparture = DateTime.Now;

            Assert.That(_emp.Departure, Is.EqualTo(expectedDeparture).Within(TimeSpan.FromHours(3.0)));
        }
    }
}
