using Admin_Service.Tokens;
using Admin_Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Admin_Service.Controllers
{
    [Route("token")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]LoginViewModel inputModel)
        {
            if (inputModel.Email != "admin@testing.com" && inputModel.Password != "Password1!")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("adminService-secret-key"))
                                .AddSubject("invoiceService")
                                .AddIssuer("adminService.Security.Bearer")
                                .AddAudience("inviceService.Security.Bearer")
                                .AddClaim("", "")
                                .AddExpiry(1)
                                .Build();

            //return Ok(token);
            return Ok(token.Value);
        }
    }
}
