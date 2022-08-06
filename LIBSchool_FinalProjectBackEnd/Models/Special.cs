using System.ComponentModel.DataAnnotations;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Special
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Email boş göndərilə bilməz"),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
