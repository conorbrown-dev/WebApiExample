using System.Text.Json.Serialization;

namespace WebApplication1.Entities;

// This type is an entity, also sometimes called a model.
// This represents a single row within our Users DB table
// We can add validations to these so that email addresses
// are formatted correctly, etc.
public class User
{
    public int UserId { get; set; }

    public required string EmailAddress { get; set; }

    public required string PasswordHash { get; set; }

    [JsonRequired] public bool IsVerified { get; set; }

    // The = here is setting a default value for CreatedAt
    // Which allows the User type to be constructed without specifying the CreatedAt date
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}