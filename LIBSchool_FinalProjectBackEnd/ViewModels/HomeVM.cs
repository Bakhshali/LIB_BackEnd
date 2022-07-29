using LIBSchool_FinalProjectBackEnd.Models;
using System.Collections.Generic;

namespace LIBSchool_FinalProjectBackEnd.ViewModels
{
    public class HomeVM
    {
        public List<Setting> Settings { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Course> Courses { get; set; }
        public Course Course { get; set; }
        public List<Quiz> Quizzes { get; set; }

    }
}
