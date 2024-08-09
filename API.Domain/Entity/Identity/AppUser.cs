using Microsoft.AspNetCore.Identity;

namespace API.Domain.Entity.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public DateTime CreatedDate { get; set; }
    }
}
