﻿using API.Domain.Entity.Common;

namespace API.Domain.Entity;

public class Dish : BaseEntity
{
    public string MenuId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; } // Photo URL or Path

    // Navigation Properties
    public Menu Menu { get; set; }
}