﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application_.DTOs.User
{
    public class CreateUserDto
    {
        public string id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswrodConfirm { get; set; }
    }
}
