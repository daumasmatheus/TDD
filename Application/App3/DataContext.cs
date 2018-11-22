using System.Data.Entity;

namespace Application.App3
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

        }

        public virtual DbSet<Person> Persons { get; set; }
    }
}
