using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEF
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Addresse { get; set; }
        public DbSet<Email> Email { get; set; }
    }
}