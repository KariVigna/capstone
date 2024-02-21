using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;

namespace Capstone.Models
{
    public class Entry
    {
        public int EntryId { get; set; }
        public string Title { get; set; }
        public int Reward { get; set; }
        public string Description { get; set; }
    }
}