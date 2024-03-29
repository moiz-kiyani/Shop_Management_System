﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class User
    {
        [Column("ID")]
        public virtual int Id { get; set; }

        [Column("Name")]
        public virtual string Name { get; set; }

        [Column("Email")]
        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        [Column("Password")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public virtual string Password { get; set; }
    }
}
