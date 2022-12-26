﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Models
{
    public class Task
    {
       // [Key]
        public Guid TaskId { get; set; }

       // [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

       // [Required]
       // [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Points { get; set; }

        public int Stars { get; set; }

        public Priority TaskPriority { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public virtual Category Category { get; set; }

        //[NotMapped]
        public string Resumen { get; set; } 
    }
    
    public enum Priority
    {
        Low,
        Mid,
        High
    }
}
