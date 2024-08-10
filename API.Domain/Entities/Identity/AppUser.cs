using Microsoft.AspNetCore.Identity;

namespace API.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public DateTime CreatedDate { get; set; }
    }
}
