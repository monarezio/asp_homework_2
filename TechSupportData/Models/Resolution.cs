using System;
using System.ComponentModel.DataAnnotations;

namespace TechSupportData.Models
{
    /// <summary>
    /// This class is optional, I am implementing it, because it seems odd to me, to not save/log the answers
    /// </summary>
    public class Resolution
    {
        [Key]
        [Required]
        public int ResultionId { get; set; }

        [Required]
        public DateTime DateTimeResolved { get; set; } = DateTime.Now;
        
        [Required]
        public int QuestionId { get; set; }

        public string AttachmentFileName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Answer { get; set; }

        public Question Question { get; set; }
    }
}