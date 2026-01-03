using WebApplication1.Entities;

namespace WebApplication1.Dtos;

// here we have the primary constructor again where we are injecting our User
// type in order to populate the values in this DTO.
public class UserResponse(User user)
{
    public DateTime CreatedAt { get; set; } = user.CreatedAt;
    public string EmailAddress { get; set; } = user.EmailAddress;
    public int UserId { get; set; } = user.UserId;
}