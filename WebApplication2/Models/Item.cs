using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Your Item Name can contain only 20 characters")]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "Your Item Description can contain only 100 characters")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public string Image { get; set; }
        [DisplayName("Post Creation Date")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public string ApplicationUserId { get; set; }

        [StringLength(20)]
        public string Category { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
        public ICollection<Item> Items { get; set; }
    }
}
