using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("/claims")]
    [Authorize]
    public class ClaimsController : ControllerBase
    {
        public IActionResult GetAllClaims()
        {
            return Ok(User.Claims.Select(c => new { Type = c.Type, Value = c.Value }));
        }
    }
}
