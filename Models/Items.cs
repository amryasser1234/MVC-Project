using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectOwn.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Real Price")]
        [Range(10, 1000 , ErrorMessage = "The {0} should between {1} To {2}")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string? ImagesPath { get; set; }
        [NotMapped]
        public IFormFile ClientFile { get; set; }

        public Category? Category { get; set; }
    }
}
