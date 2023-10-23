using GalanjBarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GalanjBarberShop;

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
