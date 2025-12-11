using Xunit;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MySolution.API;
using MySolution.Core.Entities;
using MySolution.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MySolution.API.Tests.Controllers;
public class CustomersControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public CustomersControllerTests(WebApplicationFactory<Program> factory) => _factory = factory;

    [Fact]
    public async System.Threading.Tasks.Task Get_returns_notfound_for_missing_customer()
    {
        var client = _factory.CreateClient();
        var id = System.Guid.NewGuid();
        var res = await client.GetAsync($"/api/customers/{id}");
        res.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async System.Threading.Tasks.Task Get_returns_customer_when_exists()
    {
        // Use a factory with a scoped service to seed the in-memory SQLite or in-memory DB
        var factory = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Replace AppDbContext with InMemory for tests
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                if (descriptor != null) services.Remove(descriptor);
                services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("testdb"));
                // Build service provider to seed data
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();
                db.Add(new Customer("Seeded"));
                db.SaveChanges();
            });
        });

        var client = factory.CreateClient();
        // fetch seeded customer by querying list or reading first id via a small helper endpoint is not present,
        // so we will query the DB directly to get the seeded id then call the API.
        using var scope = factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var seeded = await dbContext.Customers.FirstAsync();
        var res = await client.GetAsync($"/api/customers/{seeded.Id}");
        res.StatusCode.Should().Be(HttpStatusCode.OK);
        var customer = await res.Content.ReadFromJsonAsync<Customer>();
        customer.Should().NotBeNull();
        customer!.Name.Should().Be("Seeded");
    }
}
