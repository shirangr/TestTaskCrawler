using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskCrawler.Models
{
    public class Account
    {

        public Account()
        {
            this.Products = new List<Product>(); //many to many realtionship
        }

        [EmailAddress]
        [Required(ErrorMessage = "Please specify a user name")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Username")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please specify a password")]
        [StringLength(9, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime FirstTimeLoggedIn { get; set; }

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime LastLoggedIn { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
