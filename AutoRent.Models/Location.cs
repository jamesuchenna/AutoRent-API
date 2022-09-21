using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRent.Models
{
    public class Location
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public string Name 
        { 
            get{ return $"{Area}, {State}"; }
        }

        [Required]
        [StringLength(5)]
        public string StreetNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [StringLength(30)]
        public string Area { get; set; }

        [Required]
        [StringLength(10)]
        public string State { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
