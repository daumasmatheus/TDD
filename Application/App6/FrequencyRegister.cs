using System;

namespace Application.App6
{
    public class FrequencyRegister
    {
        public void RegisterEntrance(CompanyEmployee employee)
        {
            employee.Entrance = DateTime.Now;
        }
    }
}
