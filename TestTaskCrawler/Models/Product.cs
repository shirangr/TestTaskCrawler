﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskCrawler.Models
{
    public class Product
    {
        public string EmailAccount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Address { get; set; } //PK- **comment: I decided to choose as pk because url is unique for each product
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public int Price { get; set; }
        public int ShippingPrice { get; set; }
        public string ImagePath { get; set; }

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime LastViewed { get; set; }

        public string BackgroundPageColor { get; set; }


        public virtual ICollection<Account> Accounts { get; set; }
    }
}