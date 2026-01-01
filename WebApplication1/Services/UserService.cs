using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class UserService(IUserRepo userRepo) : IUserService
{
    public IEnumerable<User> GetAll()
    {
        return userRepo.GetAll();
    }

    public async Task<UserResponse> CreateAsync(UserRequest userRequest)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);

        var user = new User
        {
            EmailAddress = userRequest.EmailAddress,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow
        };

        var createdUser = await userRepo.CreateAsync(user);

        return new UserResponse(createdUser);
    }

    public Task<UserResponse> CreateAsync(UserRequest userRequest, string passwordHash)
    {
        throw new NotImplementedException();
    }
}