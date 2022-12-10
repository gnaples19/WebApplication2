using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.ViewModels
{
    public class ItemCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [StringLength(20)]

        private SelectList _Category { get; set; }
        public string Category { get; set; }
        [Required]

        public IFormFile ImageSource { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
