namespace Application.App3
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
