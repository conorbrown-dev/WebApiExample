using System.Text.Json.Serialization;

namespace WebApplication1.Entities;

public class User
{
    public int UserId { get; set; }

    public required string EmailAddress { get; set; }

    public required string PasswordHash { get; set; }

    [JsonRequired] public bool IsVerified { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}