using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskCrawler.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Url)]
        public string ProductURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        //[DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        //[DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal ShippingPrice { get; set; }
        public string ImagePath { get; set; }
        public string BackgroundPageColor { get; set; }


        //public string Username { get; set; }

        [ForeignKey("Username")]
        public Account Account { get; set; }
    }
}
