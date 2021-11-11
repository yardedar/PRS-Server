﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PRS_Server.Models
{
    public class User
    {
        public User()
        {
           
        }

        public int Id { get; set; }
        [StringLength(30), Required]
        public string Username { get; set; }
        [StringLength(30), Required]
        public string Password { get; set; }
        [StringLength(30), Required]
        public string FirstName { get; set; }
        [StringLength(30), Required]
        public string LastName { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
