using WebApplication1.Entities;

namespace WebApplication1.Repositories;

// interfaces are basically contracts/templates/abstractions that define a set of behaviors.
// The behaviors themselves are implemented in the inherited classes or concretions (in this case it would be the UserRepo class).
// This has advantages when you need to do something like store a User in CosmosDB instead of SQL
// It's also great for testing because you can create an IUserRepoMock mock that basically does nothing but return dummy data
// This allows you to test your logic without accessing the DB, or 3rd party dependencies which should not be part of unit testing
public interface IUserRepo
{
    IEnumerable<User> GetAll();

    Task<User> CreateAsync(User user);
}