using System.Collections.Generic;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public List<Course> Courses { get; set; }
    }
}
