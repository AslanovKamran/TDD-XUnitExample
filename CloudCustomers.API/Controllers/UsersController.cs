using CloudCustomers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

	public IUserService _userService { get; }
	public UsersController(IUserService service)
	{
		_userService = service;
	}


	[HttpGet]
	[Route("GetUsers")]
    public async Task<IActionResult>Get()
    {
		var users = await _userService.GetAllUsers();
		var users2 = await _userService.GetAllUsers();
		if (users.Any()) { return Ok(users); }
		return NotFound();
    }
}
