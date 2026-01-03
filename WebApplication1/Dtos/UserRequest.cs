namespace WebApplication1.Dtos;

public class UserRequest
{
    // the getters and setters here are so that default read and write behaviors can be 
    // customized. For example if you wanted to prepend the email address
    // with the persons first name, you could do that in the getter.
    // This type of behavior isn't used super often but it is there.
    public string EmailAddress { get; set; }

    public string Password { get; set; }
}