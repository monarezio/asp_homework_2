using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechSupportData.Models
{
    public class ProductType
    {
        [Key]
        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        
        public IList<Product> Products { get; set; }
    }
}