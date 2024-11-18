using Microsoft.AspNetCore.Identity;

namespace ForumMotor.Models
{
    public class User : IdentityUser
    {
        string? VezetekNev { get; set; }
        string? KeresztNev { get; set; }
    }
}
