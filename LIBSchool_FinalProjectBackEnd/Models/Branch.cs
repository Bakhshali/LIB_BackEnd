using System.ComponentModel.DataAnnotations;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string OfficeNumber { get; set; }

        public string Map { get; set; }
    }
}
