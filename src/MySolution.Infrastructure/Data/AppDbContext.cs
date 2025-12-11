using Microsoft.EntityFrameworkCore;
using MySolution.Core.Entities;
namespace MySolution.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) {}
    public DbSet<Customer> Customers => Set<Customer>();
}
