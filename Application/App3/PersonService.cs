using System;

namespace Application.App3
{
    public class PersonService : PersonRepository, IPersonService
    {
        public PersonService() : base(new DataContext())
        {

        }

        public void AddNewPerson(Person Person)
        {
            if (String.IsNullOrEmpty(Person.FirstName))
                throw new ArgumentNullException();

            Add(Person);
            SaveChanges();
        }
    }
}
