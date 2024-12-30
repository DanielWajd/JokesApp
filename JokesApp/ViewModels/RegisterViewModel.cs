using JokesApp.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace JokesApp.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "EmailAddress")]
        [Required(ErrorMessage = "EmailAddress")]
        public string EmailAddress { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password dont match")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Surname must contain only letters.")]
        public string Surname { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Phone number must consist of exactly 9 digits.")]
        public string Phone { get; set; }
        [Display(Name = "UserType")]
        [Required(ErrorMessage = "UserType")]
        public UserType UserType { get; set; }
    }
}
