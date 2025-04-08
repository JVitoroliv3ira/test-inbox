using Microsoft.AspNetCore.Mvc;
using TestInbox.Api.Application.Interfaces.UseCases;
using TestInbox.Api.Presentation.Dtos.Input;

namespace TestInbox.Api.Presentation.Controllers.V1;

[Route("v1/[controller]")]
[ApiController]
public class EmailController(
    IGetEmailDetailsUseCase getEmailDetailsUseCase,
    IListEmailsUseCase listEmailsUseCase
) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Detail(int id, CancellationToken ct)
    {
        var result = await getEmailDetailsUseCase.ExecuteAsync(id, ct);

        return result.Match<IActionResult>(
            l => l.ToActionResult(),
            Ok
        );
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] PaginatedQueryInputDto query, CancellationToken ct)
    {
        var result = await listEmailsUseCase.ExecuteAsync(query, ct);
        
        return Ok(result);
    }
}