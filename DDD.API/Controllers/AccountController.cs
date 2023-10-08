
using DDD.Application.Features.Users.Commands.Login;
using DDD.Application.Features.Users.Commands.Register;
using DDD.Application.Features.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ISender _sender;

    public AccountController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody]UserRegisterCommand command)
    {
        return Ok(await _sender.Send(command));
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        return Ok(await _sender.Send(command));
    }
    
}