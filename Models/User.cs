﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwweb_rhino.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
