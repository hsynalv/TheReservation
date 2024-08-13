﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application_.DTOs.Review
{
    public class GetUserReviewDto
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string RestaurantName { get; set; }
    }
}
