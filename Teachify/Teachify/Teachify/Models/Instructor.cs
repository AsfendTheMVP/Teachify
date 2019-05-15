using System;
using System.Collections.Generic;
using System.Text;

namespace Teachify.Models
{
    public class Instructor
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Language { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string OneLineTitle { get; set; }
        public string Description { get; set; }
        public string Experience { get; set; }
        public string HourlyRate { get; set; }
        public string CourseDomain { get; set; }
        public string City { get; set; }
        public object ImageArray { get; set; }
        public string ImagePath { get; set; }       
        public string FullLogoPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImagePath))
                {
                    return string.Empty;
                }
                return String.Format("https://teachify.azurewebsites.net/{0}",ImagePath.Substring(1));
            }
        }
    }
}
