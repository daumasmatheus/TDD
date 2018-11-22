using System;
using System.Globalization;

namespace Application.App5
{
    public class DateTimeServices
    {
        public bool CompareTwoDates(DateTime value_1, DateTime value_2)
        {
            return value_1 == value_2 ? true : false;
        }

        public bool CompareTwoHours(string hour_1, string hour_2)
        {
            return hour_1 == hour_2 ? true : false;
        }

        public object CheckIfFirstDateIsTheHigher(string date_1, string date_2)
        {
            var date_1_parsed = ParseDate(date_1);
            var date_2_parsed = ParseDate(date_2);

            return date_1_parsed > date_2_parsed ? true : false;
        }

        public object CheckIfFirstDateIsTheLower(string date_1, string date_2)
        {
            var date_1_parsed = ParseDate(date_1);
            var date_2_parsed = ParseDate(date_2);

            return date_1_parsed < date_2_parsed ? true : false;
        }

        public object CheckIfFirstHourIsTheHigher(string time_1, string time_2)
        {
            var time_1_parsed = ParseTime(time_1);
            var time_2_parsed = ParseTime(time_2);

            return time_1_parsed > time_2_parsed ? true : false;
        }

        public object CheckIfFirstHourIsTheLower(string time_1, string time_2)
        {
            var time_1_parsed = ParseTime(time_1);
            var time_2_parsed = ParseTime(time_2);

            return time_1_parsed < time_2_parsed ? true : false;
        }

        private DateTime ParseDate(string date)
        {
            DateTime dateParsed = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return dateParsed;
        }

        private DateTime ParseTime(string time)
        {
            DateTime timeParsed = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);

            return timeParsed;
        }
    }
}
