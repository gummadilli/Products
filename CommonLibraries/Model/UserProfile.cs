using System;
using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class UserProfile
    {
        [Key]
        public long UserProfileId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
