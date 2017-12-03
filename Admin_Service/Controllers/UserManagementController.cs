using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Admin_Service.Data;
using Admin_Service.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Admin_Service.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly StaffContext _dbContext;

        public UserManagementController(StaffContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ////var vm = new UserManagementIndexViewModel
            //{ 
            // Users = _dbContext.Users.OrderBy(u => u.Email).ToList ()
            //};

            return View();
        }
    }
}
