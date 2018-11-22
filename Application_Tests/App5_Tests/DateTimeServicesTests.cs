using Application.App5;
using NUnit.Framework;
using System;

namespace Application_Tests.App5_Tests
{
    [TestFixture]
    class DateTimeServicesTests
    {
        private DateTimeServices _dateTimeServices;

        [SetUp]
        public void Setup()
        {
            _dateTimeServices = new DateTimeServices();
        }

        [TearDown]
        public void TearDown()
        {
            _dateTimeServices = null;
        }

        [Test]
        public void CompareDates_ShouldCompareIfTwoDatesAreTheSame()
        {
            DateTime date_1 = DateTime.UtcNow.Date;
            DateTime date_2 = DateTime.UtcNow.Date;

            var result = _dateTimeServices.CompareTwoDates(date_1, date_2);
            bool expectedResult = true;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CompareTimes_ShouldCompareIfTwoHoursAreTheSame()
        {
            string time_1 = DateTime.Now.ToString("HH:mm:ss");
            string time_2 = DateTime.Now.ToString("HH:mm:ss");

            var result = _dateTimeServices.CompareTwoHours(time_1, time_2);
            bool expectedResult = true;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckIfFirstDateIsHigherThanOther_ShouldReturnTrue()
        {
            string date_1 = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy");
            string date_2 = DateTime.Now.ToString("dd/MM/yyyy");

            var result = _dateTimeServices.CheckIfFirstDateIsTheHigher(date_1, date_2);
            bool expectedResult = true;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckIfFirstDateIsLowerThanOther_ShouldReturnTrue()
        {
            string date_1 = DateTime.Now.ToString("dd/MM/yyyy");
            string date_2 = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy");

            var result = _dateTimeServices.CheckIfFirstDateIsTheLower(date_1, date_2);
            bool expectedResult = true;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckIfTheFirsHourIsHiherThanOther_ShouldReturnTrue()
        {
            string time_1 = DateTime.Now.AddHours(5).ToString("HH:mm:ss");
            string time_2 = DateTime.Now.ToString("HH:mm:ss");

            var result = _dateTimeServices.CheckIfFirstHourIsTheHigher(time_1, time_2);
            bool expectedResult = true;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckIfTheFirstHourIsLowerThanOther_ShouldReturnTrue()
        {
            string time_1 = DateTime.Now.ToString("HH:mm:ss");
            string time_2 = DateTime.Now.AddHours(5).ToString("HH:mm:ss");

            var result = _dateTimeServices.CheckIfFirstHourIsTheLower(time_1, time_2);
            bool expectedResult = true;

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
