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
        public List<Writeus> Writeuss { get; set; }
        public List<Career> Careerss { get; set; }
        public List<Special> Specials { get; set; }
        public Contact Contact { get; set; }
        public Career Careers { get; set; }
        public Writeus Writeus { get; set; }
        public Special Special { get; set; }


        public List<QuizInfo> QuizInfos { get; set; }
        public QuizInfo QuizInfo { get; set; }
        public List<QuizTeacher> QuizTeachers { get; set; }
        public List<QuizTime> QuizTimes { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public BasketItem BasketItem { get; set; }
        public List<CourseEducation> CourseEducations { get; set; }
        public CourseEducation CourseEducation { get; set; }


    }
}
