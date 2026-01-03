using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

// Here we declare that this class is in the WebApplication1.Context namespace
// If you had other classes in the Context folder they would also share that namespace
namespace WebApplication1.Context;

// This partial class inherits from Microsoft's DbContext type
// Since we inherit from it we get DB functionality, and methods to override in order to set up our DB
// Having a partial class allows you to extend the functionality of a class
public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // This represents a table within the DB
    public DbSet<User> Users { get; set; }

    // This allows you to setup foreign key relationships between tables, and other stuff 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    // This is just a method for running OnModelCreating for the extended partial class if you have one
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}