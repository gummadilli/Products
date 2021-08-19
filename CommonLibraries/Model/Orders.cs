using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Orders
    {
        [Key]
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime ShipDate { get; set; }
        public string Terms { get; set; }
        public bool Quantity { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
