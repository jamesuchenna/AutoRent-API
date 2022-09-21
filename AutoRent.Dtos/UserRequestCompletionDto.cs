using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class UserRequestCompletionDto
    {
        public string HomeAddress { get; set; }
        public string NextOfKinName { get; set; }
        public string NextOfKinContact { get; set; }
        public string NextOfKinAddress { get; set; }
        public string DrivingLicenceImage { get; set; }
        public string UserImageUrl { get; set; }
    }
}
