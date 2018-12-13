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
            this.Products = new List<Product>();
        }

        [Required]
        [EmailAddress]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Username { get; set; }

        [Required]
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
