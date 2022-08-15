using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Course
    {
        public int Id { get; set; }

        
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }

        public string SubName { get; set; }
        
        public string İnformation { get; set; }
        
        public string BelongTitle { get; set; }

        public string BelongText { get; set; }

        public string Condition { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }


        [NotMapped]
        public IFormFile Photo { get; set; }

        public List<CourseEducation> CourseEducations { get; set; }

        [NotMapped]
        public List<int> CourseEducationId { get; set; }


        [NotMapped]
        public List<int> EducationId { get; set; }




    }
}
