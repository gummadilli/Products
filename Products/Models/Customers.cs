using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Customers
    {
        [Key]
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }

    }
}
