using Microsoft.AspNetCore.Mvc;
using TestInbox.Api.Application.Interfaces;

namespace TestInbox.Api.Presentation.Controllers.V1;

[Route("v1/[controller]")]
[ApiController]
public class EmailController(
    IGetEmailDetailsUseCase getEmailDetailsUseCase
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
}