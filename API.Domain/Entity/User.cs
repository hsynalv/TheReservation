using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Domain.Entity.Identity;

namespace API.Domain.Entity
{
    public class User : AppUser 
    {
        public string? ProfilePicture { get; set; }

        public decimal Score { get; set; }
        // Navigation Properties
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
