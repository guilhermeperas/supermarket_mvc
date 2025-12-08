using System.ComponentModel.DataAnnotations;

namespace Supermarket.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
