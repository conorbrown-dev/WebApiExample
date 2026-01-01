using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public interface IUserRepo
{
    IEnumerable<User> GetAll();

    Task<User> CreateAsync(User user);
}