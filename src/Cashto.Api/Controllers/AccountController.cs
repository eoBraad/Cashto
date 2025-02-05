using System.Security.Claims;
using Cashto.Application.UseCases.Account.Create;
using Cashto.Communication.Requests.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cashto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateAccountRequestJson request,
        [FromServices] ICreateAccountUseCase createAccountUseCase)
    {
        var userId = base.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;

        await createAccountUseCase.Execute(request, userId!);

        return Created("", null);
    }
}