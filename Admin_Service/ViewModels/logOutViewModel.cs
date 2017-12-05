using System.ComponentModel.DataAnnotations;

namespace Admin_Service.ViewModels
{
    public class logOutViewModel
    {
        [Display(Name = "LogOut")]
        public bool Logout { get; set; }
    }
}
