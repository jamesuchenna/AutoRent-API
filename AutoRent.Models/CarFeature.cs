using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoRent.Models
{
    /// <summary>
    /// pivot/joining class for implementing many-to-many relationship
    /// between Car and Feature
    /// </summary>
    public class CarFeature
    {
        [Required]
        [ForeignKey("Car")]
        public string CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        [ForeignKey("Feature")]
        public string FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
