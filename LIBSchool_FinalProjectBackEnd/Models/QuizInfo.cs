using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class QuizInfo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Listener { get; set; }

        public int QuizTeacherId { get; set; }
        public QuizTeacher QuizTeacher { get; set; }

        public int QuizTimeId { get; set; }
        public QuizTime QuizTime { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
