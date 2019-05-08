using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSupportData.Models.Attributes;

namespace TechSupportData.Models
{
    public class Question
    {
        [Key]
        [Required]
        public int QeustionId { get; set; }

        [Required]
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Body { get; set; }

        [Required]
        [ClientEmail]
        public string Email { get; set; }

        [Required]
        public bool IsAttachment { get; set; }

        public Resolution Resolution { get; set; }

        [NotMapped]
        public bool IsResolved => Resolution != null;

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}