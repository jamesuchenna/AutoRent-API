using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class RatingRequestDto
    {
        public string Title { get; set; }
        public int Stars { get; set; }
        public string Review { get; set; }

        public string UserId { get; set; }
        public string CarId { get; set; }
    }
}
