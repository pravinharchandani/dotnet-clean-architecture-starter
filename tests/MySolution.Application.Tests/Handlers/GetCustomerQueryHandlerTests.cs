using Xunit;
using Moq;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using MySolution.Application.Handlers;
using MySolution.Application.Requests;
using MySolution.Core.Interfaces;
using MySolution.Core.Entities;

namespace MySolution.Application.Tests.Handlers;
public class GetCustomerQueryHandlerTests
{
    [Fact]
    public async Task Handler_calls_repository_and_returns_customer()
    {
        var id = System.Guid.NewGuid();
        var expected = new Customer("Bob");
        var repoMock = new Mock<ICustomerRepository>();
        repoMock.Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(expected);

        var handler = new GetCustomerQueryHandler(repoMock.Object);
        var result = await handler.Handle(new GetCustomerQuery(id), CancellationToken.None);

        result.Should().BeSameAs(expected);
        repoMock.Verify(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}
