﻿using API.Domain.Entities.Common;
using API.Domain.Entities.Identity;

namespace API.Domain.Entities
{
    public class Customer : BaseEntity 
    {
        public string? ProfilePicture { get; set; }

        public decimal? Score { get; set; }
        // Navigation Properties
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        // Navigation Property
        public AppUser AppUser { get; set; }
    }
}
