using Xunit;
using FluentAssertions;
using MySolution.Core.Entities;
namespace MySolution.Core.Tests.Entities;
public class CustomerTests
{
    [Fact]
    public void Creating_customer_sets_name_and_id()
    {
        var name = "Alice";
        var c = new Customer(name);
        c.Name.Should().Be(name);
        c.Id.Should().NotBe(System.Guid.Empty);
    }
}
