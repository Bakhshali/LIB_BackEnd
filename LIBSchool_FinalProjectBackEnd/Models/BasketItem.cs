using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public int Count { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        [Column(TypeName ="decimal(5,2)")]
        public decimal? Price { get; set; }

    }
}
