﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matchplanner.Shared.DTO
{
    public class LoginRequestDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
