using System;
using System.ComponentModel.DataAnnotations;

namespace TestTaskCrawler.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductURL { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Condition { get; set; }

        public int Price { get; set; }

        public int ShippingPrice { get; set; }

        public string ImagePath { get; set; }

        //[NotMapped]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime LastViewed { get; set; }

        //[NotMapped]
        public string BackgroundPageColor { get; set; }

        
        //public ICollection<Account> Accounts { get; set; }
    }
}
