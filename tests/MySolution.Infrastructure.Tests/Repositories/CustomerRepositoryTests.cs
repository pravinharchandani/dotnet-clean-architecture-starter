using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MySolution.Infrastructure.Data;
using MySolution.Infrastructure.Repositories;
using MySolution.Core.Entities;
using System.Threading.Tasks;

namespace MySolution.Infrastructure.Tests.Repositories;
public class CustomerRepositoryTests
{
    private AppDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task Add_and_get_customer_should_work()
    {
        using var db = CreateInMemoryContext();
        var repo = new CustomerRepository(db);
        var c = new Customer("Charlie");
        await repo.AddAsync(c);
        var fetched = await repo.GetByIdAsync(c.Id);
        fetched.Should().NotBeNull();
        fetched!.Name.Should().Be("Charlie");
    }
}
