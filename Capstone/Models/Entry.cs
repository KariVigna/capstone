using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;

namespace Capstone.Models
{
    public class Entry
    {
        public int EntryId { get; set; }
        [Required(ErrorMessage = "Task title cannot be empty!")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Set a reward value!")]
        public int Reward { get; set; }
        public string Description { get; set; }
        [Display(Name = "Completed?")]
        public bool IsComplete { get; set; }
    }
}