using Microsoft.AspNetCore.Mvc;
using WalletApp.Core.Models;
using WalletApp.Service;

namespace WalletApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var users = await _userService.GetListOfUserAsync();

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserModel model)
    {
        await _userService.CreateUserAsync(model);

        return Ok();
    }
}