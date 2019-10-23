using System.Threading.Tasks;
using SE.DataObjects.Auth;
using SE.Service.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using SE.Service.Helpers;

namespace SE.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        StringValues tokenHeaders;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(AuthDto authDto)
        {
            var result = await _authService.Login(authDto);
            var e = JsonConvert.SerializeObject(new Token { Id = 1 });
            result.ResponseMessage = HashingHelper.Encrypt(e);
            return Ok(result);
        }
    }
}