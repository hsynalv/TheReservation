using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Features.Command.AppUser.CreateUser;

namespace API.Application_.Features.Command.Customer.CreateCustomer
{
    public class CreateCustomerCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
