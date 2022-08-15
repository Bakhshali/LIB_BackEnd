using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Questions { get; set; }

        public List<Answer> Answers { get; set; }

    }
}
