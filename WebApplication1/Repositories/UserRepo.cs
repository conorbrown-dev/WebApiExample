using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

// The concretion of the IUserRepo abstraction
// This is where the DB magic happens
public class UserRepo(AppDbContext db) : IUserRepo
{
    public IEnumerable<User> GetAll()
    {
        return db.Users;
    }

    public async Task<User> CreateAsync(User user)
    {
        // the db.Users is the magical bit. 
        // We can perform lookups, CRUD operations, etc. by accessing this table
        var createdUser = await db.Users.AddAsync(user);
        await db.SaveChangesAsync();

        return createdUser.Entity;
    }
}