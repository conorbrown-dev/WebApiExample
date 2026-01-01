using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services;

public interface IUserService
{
    IEnumerable<User> GetAll();

    Task<UserResponse> CreateAsync(UserRequest userRequest);
}