using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TechSupportData.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        
        [Required]
        public int ProductTypeId { get; set; }
        
        public ProductType ProductType { get; set; }
    }
}