using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PRS_Server.Models
{
    public class Product
    {
        public Product()
        {
         
        }

        public int Id { get; set; }
        [StringLength(30), Required]
        public string PartNbr { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; }
        [StringLength(5), Required]
        public string Unit { get; set; }
        [StringLength(255)]
        public string PhotoPath { get; set; }
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; } 
    }
}
