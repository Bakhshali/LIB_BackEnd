namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
