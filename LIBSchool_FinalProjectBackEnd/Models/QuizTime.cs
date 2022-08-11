using System.Collections.Generic;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class QuizTime
    {
        public int Id { get; set; }

        public int Time { get; set; }

        public List<QuizInfo> QuizInfos { get; set; }
    }
}
