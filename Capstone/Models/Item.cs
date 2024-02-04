using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Capstone.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}