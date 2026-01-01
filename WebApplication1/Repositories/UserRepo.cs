using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class UserRepo(AppDbContext db) : IUserRepo
{
    public IEnumerable<User> GetAll()
    {
        return db.Users;
    }

    public async Task<User> CreateAsync(User user)
    {
        var createdUser = await db.Users.AddAsync(user);
        await db.SaveChangesAsync();

        return createdUser.Entity;
    }
}