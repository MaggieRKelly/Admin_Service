
using System.ComponentModel.DataAnnotations;


namespace Admin_Service.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password does notmatch the confirmation password.")]
        public string ConfirmPassword { get; set;}
    }
}
