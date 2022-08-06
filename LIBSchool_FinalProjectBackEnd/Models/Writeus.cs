using System.ComponentModel.DataAnnotations;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Writeus
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bütün hissələrin düzgün doldurulmasından əmin olduqdan sona yenidən cəhd edin.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bütün hissələrin düzgün doldurulmasından əmin olduqdan sona yenidən cəhd edin.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Telefon nömrəsi düzgün deyil(nömrə 0 ilə başlamalıdır).")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Bütün hissələrin düzgün doldurulmasından əmin olduqdan sona yenidən cəhd edin."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bütün hissələrin düzgün doldurulmasından əmin olduqdan sona yenidən cəhd edin.")]
        public string Subject { get; set; }
    }
}
