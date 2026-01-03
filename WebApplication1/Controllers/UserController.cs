using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Services;

// same deal here with the namespace
namespace WebApplication1.Controllers;

// this enforces model validation and returns appropriate status codes 
// when a resource doesn't exist, auth is invalid, etc.
[ApiController]
// This sets our base URL to the name of the controller excluding the "Controller" bit
// So the base URL for this UserController would be "/User" NOT "/UserController"
[Route("[controller]")]
// The bit with the parenthesis is a primary constructor. Back in the old days 
// we would have to declare a cosntructor and it's body and fields within
// the Controller class. This was boilerplate and verbose so now
// we can just put our arguments or in this case dependencies in the parenthesis and
// we are good to go. 
public class UserController(IUserService userService) : ControllerBase
{
    // This is the old way of injecting a dependency into a controller
    // horribly verbose and lame

    // private readonly IUserService _userService;
    //
    // public UserController(IUserService userService)
    // {
    //     _userService = userService;
    // }

    // This specifies this endpoint as a GET request
    // A route path can be specified here if we need to access it at "/User/GetAllUsers"
    // We would do this by using:
    // [HttpGet("GetAllUsers")]
    [HttpGet]
    public IEnumerable<User> GetAll() // IEnumerable is a basic collection for enumerating (otherwise known as looping) object/entities 
    {
        return userService.GetAll();
    }

    // HttpPost indicates that we are sending data in the body of the request to this endpoint
    // for creating a user. Think of it as a form submission where data is entered into the page
    // and sent off to the server as JSON in the body of the HTTP request.
    [HttpPost]
    public async Task<ActionResult> Create(UserRequest user)
    {
        var createdUser = await userService.CreateAsync(user);

        // Here we return a CreatedAtAction so that we can return a 201 Created status code instead 200 OK
        // This helps the frontend know that the requested resource was created successfully. 
        // In order to use this type we must indicate that we're returning an IActionResult (which CreatedAtAction inherits from)
        return CreatedAtAction(nameof(Create), new
        {
            id = createdUser.UserId
        }, createdUser);
    }
}