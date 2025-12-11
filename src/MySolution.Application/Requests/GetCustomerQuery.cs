using MediatR;
using MySolution.Core.Entities;
namespace MySolution.Application.Requests;
public record GetCustomerQuery(System.Guid Id) : IRequest<Customer?>;
