using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskCrawler.Models
{
    public class Account : IdentityUser
    {
        public int ID { get; set; }

        [Key]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please specify a user name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please specify a password")]
        [StringLength(9, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
