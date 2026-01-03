using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

// Services are where logic and tragically...bugs live
// This is where the action should happen in a modern application
// All of our logic lives in here, DB calls, validation, formatting
// as well as any preprocessing that needs done before a DTO is sent to the repo layer
// and sent off to the DB. 
public class UserService(IUserRepo userRepo) : IUserService
{
    public IEnumerable<User> GetAll()
    {
        return userRepo.GetAll();
    }

    public async Task<UserResponse> CreateAsync(UserRequest userRequest)
    {
        // perfect example of a Service doing some preprocessing before a DTO is sent to the repo layer
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);

        // Here we construct a new User entity that will be saved to the DB
        var user = new User
        {
            EmailAddress = userRequest.EmailAddress,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow
        };

        var createdUser = await userRepo.CreateAsync(user);

        return new UserResponse(createdUser);
    }
}