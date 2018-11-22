using System;

namespace Application.App4
{
    public class EntranceRegistration
    {
        public void RegisterEntrance(Employee employee)
        {
            employee.Entrance = DateTime.Now;
        }

        public void RegisterInterval(Employee employee)
        {
            employee.Interval = DateTime.Now;
        }

        public void RegisterIntervalEnd(Employee employee)
        {
            employee.IntervalEnd = DateTime.Now;
        }

        public void RegisterDeparture(Employee employee)
        {
            employee.Departure = DateTime.Now;
        }
    }
}
