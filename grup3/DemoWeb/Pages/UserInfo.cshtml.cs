using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;

namespace DemoWeb.Pages
{
    public class UserInfoModel : PageModel
    {
        private readonly IHttpClientFactory _factory;
        public UserInfoModel(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public UserInfoResponse Data { get; private set; }

        public async Task OnGet()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var client = _factory.CreateClient("IdentityServer");

            var doc = await client.GetDiscoveryDocumentAsync();

            Data = await client.GetUserInfoAsync(new UserInfoRequest()
            {
                Token = token,
                Address = doc.UserInfoEndpoint
            });

        }
    }
}
