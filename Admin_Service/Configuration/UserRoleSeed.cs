using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Service.Configuration
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleSeed(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public async void Seed()
        {
            if ((await _roleManager.FindByNameAsync("Staff")) == null)
            {
               await _roleManager.CreateAsync(new IdentityRole { Name = "Staff" });
            }

            if ((await _roleManager.FindByNameAsync("Manager")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
            }

            if ((await _roleManager.FindByNameAsync("Admin")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }

        }
    }
}
