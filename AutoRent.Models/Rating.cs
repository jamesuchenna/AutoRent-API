using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoRent.Models
{
    public class Rating
    {
        [Key]
        public string Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        // check max int attribute
        //[MaxLength(5)]
        public int Stars { get; set; }
        [Column(TypeName = "ntext")]
        public string Review { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Car")]
        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}
