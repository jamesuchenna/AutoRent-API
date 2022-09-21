using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoRent.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName="ntext")]
        public string Body { get; set; }
        [Required]
        public string FeaturedImage { get; set; }
    }
}
