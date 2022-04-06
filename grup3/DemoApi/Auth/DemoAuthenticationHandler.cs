using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace DemoApi.Auth
{

    public static class DemoAuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddDemoAuth(this AuthenticationBuilder builder, string schemeName = DemoAuthenticateDefaults.AuthenticationScheme, Action<DemoAuthenticationOptions> config = null)
        {
            builder.AddScheme<DemoAuthenticationOptions, DemoAuthenticationHandler>(schemeName, config ?? (opt => { }));
            return builder;
        }
    }

    public class DemoAuthenticationOptions : AuthenticationSchemeOptions
    {
        public int MinLength { get; set; }
    }

    public static class DemoAuthenticateDefaults
    {
        public const string AuthenticationScheme = "DemoAuth";
    }

    public class DemoAuthenticationHandler : AuthenticationHandler<DemoAuthenticationOptions>
    {
        public DemoAuthenticationHandler(IOptionsMonitor<DemoAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Context.Request.Headers["Authorization"]
                .FirstOrDefault();
            if (string.IsNullOrEmpty(authHeader))
            {
                return AuthenticateResult.Fail("Header Authorization not found");
            }
            if (!authHeader.StartsWith("Custom "))
            {
                return AuthenticateResult.Fail("Authorization scheme is not Custom");
            }

            var data = authHeader.Substring("Custom ".Length);
            if (data.Length < Options.MinLength)
            {
                return AuthenticateResult.Fail("MinLength not reached");
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, data)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var ppal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(ppal, new AuthenticationProperties(), Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
