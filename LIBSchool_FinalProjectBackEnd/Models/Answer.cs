using System.ComponentModel.DataAnnotations;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Answers { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }
    }
}
