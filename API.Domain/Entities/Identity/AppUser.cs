using Microsoft.AspNetCore.Identity;

namespace API.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public DateTime CreatedDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
