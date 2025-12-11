using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySolution.Application.Requests;

namespace MySolution.API.Controllers;
[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomersController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetCustomerQuery(id));
        if (result is null) return NotFound();
        return Ok(result);
    }
}
