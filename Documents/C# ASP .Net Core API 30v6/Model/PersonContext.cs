using Microsoft.EntityFrameworkCore;
namespace API30v6.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }
        public DbSet<Person> Peoples { get; set; }
    }
}