using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MainIdentity
{
    public class CustomProfileService
            : IProfileService
    {
        private readonly ILogger<CustomProfileService> _logger;

        public CustomProfileService(ILogger<CustomProfileService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            _logger.LogInformation($"Caller:{context.Caller} Client:{context.Client} ");
            context.LogIssuedClaims(_logger);
            context.LogProfileRequest(_logger);


            context.IssuedClaims.Add(new Claim("AnotherCustomTypeClaimFromDiferentStore", "Another claim value"));

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
