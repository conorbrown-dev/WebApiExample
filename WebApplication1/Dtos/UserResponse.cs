using WebApplication1.Entities;

namespace WebApplication1.Dtos;

public class UserResponse(User user)
{
    public DateTime CreatedAt { get; set; } = user.CreatedAt;
    public string EmailAddress { get; set; } = user.EmailAddress;
    public int UserId { get; set; } = user.UserId;
}