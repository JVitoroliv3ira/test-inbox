using Microsoft.AspNetCore.Mvc;

namespace TestInbox.Api.Application.Errors;

public record ApiError(
    int Code,
    string Message
)
{
    public virtual ObjectResult ToActionResult() => new(new { Code, Message }) { StatusCode = Code };
}