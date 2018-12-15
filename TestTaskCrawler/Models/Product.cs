using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskCrawler.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string ProductURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }
        public decimal ShippingPrice { get; set; }
        public string ImagePath { get; set; }
        public string BackgroundPageColor { get; set; }


        public string Username { get; set; }
        public Account Account { get; set; }
    }
}
