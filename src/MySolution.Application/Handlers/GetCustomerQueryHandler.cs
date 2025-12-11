using MediatR;
using MySolution.Core.Interfaces;
using MySolution.Application.Requests;
using MySolution.Core.Entities;
namespace MySolution.Application.Handlers;
public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer?>
{
    private readonly ICustomerRepository _repo;
    public GetCustomerQueryHandler(ICustomerRepository repo) => _repo = repo;
    public System.Threading.Tasks.Task<Customer?> Handle(GetCustomerQuery request, System.Threading.CancellationToken ct) =>
        _repo.GetByIdAsync(request.Id, ct);
}
