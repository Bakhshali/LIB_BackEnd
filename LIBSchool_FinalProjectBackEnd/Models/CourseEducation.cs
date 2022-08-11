using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class CourseEducation
    {
        public int Id { get; set; }
        public Education Education { get; set; }
        public int EducationId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }
    }
}
