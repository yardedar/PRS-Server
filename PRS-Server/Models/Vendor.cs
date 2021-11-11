using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PRS_Server.Models
{
    public class Vendor
    {
        public Vendor() { }

        public int Id { get; set; }
        [StringLength(4), Required]
        public string Code { get; set; }
        [StringLength(30), Required]
        public string Name { get; set; }
        [StringLength(60), Required]
        public string Address { get; set; }
        [StringLength(30), Required]
        public string City { get; set; }
        [StringLength(2), Required]
        public string State { get; set; }
        [StringLength(10), Required]
        public string Zip { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }

    }
}
