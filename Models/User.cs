﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int role { get; set; }
        public User() { }

    }
}