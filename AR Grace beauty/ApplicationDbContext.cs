using AR_Grace_beauty.Models;
using Microsoft.EntityFrameworkCore;

namespace AR_Grace_beauty
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Client> Client { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<TypeService> TypeService { get; set; }
        public DbSet<Worker> Worker { get; set; }

        public ApplicationDbContext() => Database.EnsureCreated();
    }
}
