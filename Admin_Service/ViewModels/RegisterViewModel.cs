
using System.ComponentModel.DataAnnotations;


namespace Admin_Service.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256) ,Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password does not match the confirmation password.")]
        public string ConfirmPassword { get; set;}
    }
}
