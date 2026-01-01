using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public IEnumerable<User> GetAll()
    {
        return userService.GetAll();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserRequest user)
    {
        var createdUser = await userService.CreateAsync(user);

        return CreatedAtAction(nameof(Create), new { id = createdUser.UserId }, createdUser);
    }
}