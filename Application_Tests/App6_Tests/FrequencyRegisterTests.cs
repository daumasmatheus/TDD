using Application.App6;
using NUnit.Framework;
using System;

namespace Application_Tests.App6_Tests
{
    [TestFixture]
    class FrequencyRegisterTests
    {
        private CompanyEmployee _emp;
        private FrequencyRegister _freq;

        [SetUp]
        public void Setup()
        {
            _freq = new FrequencyRegister();
            
        }

        [TearDown]
        public void TearDownTests()
        {
            _freq = null;
        }


        [Test]
        public void RegisterEntrance_ShouldRegisterEmployeeEntrance()
        {
            _emp = new CompanyEmployee();
            _freq.RegisterEntrance(_emp);

            var expectedResult = DateTime.Now;

            Assert.That(_emp.Entrance, Is.EqualTo(expectedResult).Within(TimeSpan.FromHours(3)));
        }

        [Test]
        public void RegisterInterval_EntranceIsntRegistered_ShouldNotAllowRegisterInterval()
        {
            
        }
    }
}
