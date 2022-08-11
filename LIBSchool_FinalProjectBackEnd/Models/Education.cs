using System.Collections.Generic;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseEducation> CourseEducations { get; set; }

    }
}
