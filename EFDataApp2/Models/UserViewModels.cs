﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EFDataApp2.Models
{
    public class UserViewModels
    {
    }
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [UIHint ("password")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

    }

}
