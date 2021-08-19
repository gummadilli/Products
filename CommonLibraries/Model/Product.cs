using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Product
    {
        [Key]
        public long ProductId { set; get; }
        public string ProductName { set; get; }
        public string ProductType { set; get; }
        public long Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime ManufacturingDate { set; get; }
        public DateTime ExpiryDate { set; get; }
        public int Age { set; get; }
        public string Usage { set; get; }
        public string Advantages { set; get; }
        public string DisAdvantages { set; get; }
        public string ModifiedUser { set; get; }
        public DateTime ModifiedDat { set; get; }
        public bool IsActive { set; get; }
        public string CreatedUser { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}

