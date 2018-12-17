using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskCrawler.Models
{
    public class Account : IdentityUser
    {
        public int ID { get; set; }

        [Key]
        [EmailAddress]
        [Required(ErrorMessage = "Please specify a user name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please specify a password")]
        [StringLength(9, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        
        public ICollection<Product> Products { get; set; }
    }
}
