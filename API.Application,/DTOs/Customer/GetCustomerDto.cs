using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Review;

namespace API.Application_.DTOs.Customer
{
    public class GetCustomerDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePicture { get; set; }
        public decimal? Score { get; set; }
        public List<GetUserReviewDto> Reviews { get; set; }
    }
}
