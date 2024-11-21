using Cashto.Application.UseCases.User.Register;
using Cashto.Communication.Requests.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cashto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestJson request, [FromServices] IRegisterUserUseCase registerUserUseCase)
    {
        await registerUserUseCase.Execute(request);

        return Created("", null);
    }
}