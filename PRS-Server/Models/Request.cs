using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PRS_Server.Models
{
    public class Request
    {
        public Request() { }

        public int Id { get; set; }
        [StringLength(255), Required]
        public string Description { get; set; }
        [StringLength(255), Required]
        public string Justification { get; set; }
        [StringLength(100)]
        public string RejectionReason { get; set; }
        [StringLength(20), Required]
        public string DeliveryMode { get; set; }
        [StringLength(12), Required]
        public string Status { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal Total { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
       
    }
}
