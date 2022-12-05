﻿using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace SchoolSoft.Models
{
    public class Batch
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }   
    }
}
