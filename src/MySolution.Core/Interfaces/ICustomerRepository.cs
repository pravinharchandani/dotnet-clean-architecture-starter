using MySolution.Core.Entities;
namespace MySolution.Core.Interfaces;
public interface ICustomerRepository
{
    System.Threading.Tasks.Task<Customer?> GetByIdAsync(System.Guid id, System.Threading.CancellationToken ct = default);
    System.Threading.Tasks.Task AddAsync(Customer customer, System.Threading.CancellationToken ct = default);
}
