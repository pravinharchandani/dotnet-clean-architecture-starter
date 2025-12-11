using MySolution.Core.Entities;
using MySolution.Core.Interfaces;
using MySolution.Infrastructure.Data;
namespace MySolution.Infrastructure.Repositories;
public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _db;
    public CustomerRepository(AppDbContext db) => _db = db;
    public async System.Threading.Tasks.Task AddAsync(Customer c, System.Threading.CancellationToken ct = default) { _db.Add(c); await _db.SaveChangesAsync(ct); }
    public System.Threading.Tasks.Task<Customer?> GetByIdAsync(System.Guid id, System.Threading.CancellationToken ct = default) =>
        _db.Customers.FindAsync(new object[]{id}, ct).AsTask();
}
