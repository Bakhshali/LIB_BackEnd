using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class QuizTeacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<QuizInfo> QuizInfos { get; set; }
    }
}
