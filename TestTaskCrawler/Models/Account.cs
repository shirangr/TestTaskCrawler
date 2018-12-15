using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskCrawler.Models
{
    public class Account //: IdentityUser
    {
        public string UserId { get; set; }

        [Key]
        [EmailAddress]
        [Required(ErrorMessage = "Please specify a user name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please specify a password")]
        [StringLength(9, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[NotMapped]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime FirstTimeLoggedIn { get; set; }

        //[NotMapped]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? LastLoggedIn { get; set; }


        //public int Account_ProductId { get; set; }

        //public Product Account_Product { get; set; }
    }
}
