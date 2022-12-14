using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Writeus> Writeus { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<QuizInfo> QuizInfos { get; set; }
        public DbSet<QuizTeacher> QuizTeachers { get; set; }
        public DbSet<QuizTime> QuizTimes { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<WishlistItem> Wishlists { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<CourseEducation> CourseEducations { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

    }
}
