using Microsoft.AspNetCore.Identity;
using System;

namespace Admin_Service.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String Permission { get; set; }
    }
}
