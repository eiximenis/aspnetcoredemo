using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DemoWeb.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            if (UserName == Password)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, UserName));
                claims.Add(new Claim("fecha", DateTime.Now.ToString()));
                var identity = new ClaimsIdentity(claims, "patata");
                var ppal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(ppal);
            }
        }
    }
}
