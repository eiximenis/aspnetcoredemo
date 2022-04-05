using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace DemoWeb.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public string ApiResult { get; private set; }

        public async Task OnGet()
        {
            using (var http = new HttpClient())
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                http.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Bearer", token);
                var response = await http.GetAsync("https://localhost:7099/weatherforecast");
                var data = await response.Content.ReadAsStringAsync();
                ApiResult = data;
            }
        }
    }
}