using Cashto.Application.UseCases.Login;
using Cashto.Communication.Requests.Login;
using Microsoft.AspNetCore.Mvc;

namespace Cashto.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserRequestJson request,
        [FromServices] ILoginUserUseCase loginUserUseCase)
    {
        var response = await loginUserUseCase.Execute(request);
        return Ok(response);
    }
}