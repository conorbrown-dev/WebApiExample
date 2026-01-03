using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services;

// Another abstraction/contract/template that the concretion UserService inherits from
public interface IUserService
{
    IEnumerable<User> GetAll();

    Task<UserResponse> CreateAsync(UserRequest userRequest);
}