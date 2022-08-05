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
        public List<Branch> Branches { get; set; }
        public Branch Branch { get; set; }
        public List<Student> Students { get; set; }
        public List<Result> Results { get; set; }
        public List<Team> Teams { get; set; }
        public List<Album> Albums { get; set; }
        public List<Gallery> Galleries { get; set; }
        public List<Contact> Contacts { get; set; }
        public Contact Contact { get; set; }

    }
}
