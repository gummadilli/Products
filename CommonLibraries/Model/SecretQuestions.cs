using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class SecretQuestions
    {
        [Key]
        public long SecretQuestionId { get; set; }
        public long UserProfileId { get; set; }
        public string Securityquestion { get; set; }
        public string Securityanswer { get; set; }
        public string Createduser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}

