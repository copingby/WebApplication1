using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Modeles;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        
        [HttpGet]
        public async Task<string> SignIn(string username, string password)
        {
            
            using (WebApplication1Context db = new())
            {
                var user = db.Customers.SingleOrDefault(c => c.Name.Equals(username) && c.Password.Equals(password));
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Name) }
                , CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            }
            var abc = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
        }

        public IActionResult SignOut()
        {
            return View();
        }

    }
}
