using System.Threading.Tasks;
using SE.DataObjects;
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
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var result = await _authService.Login();
            var e = JsonConvert.SerializeObject(new Token { Id = 1 });
            result.ResponseMessage = HashingHelper.Encrypt(e);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Deneme()
        {
            if (Request.Headers.TryGetValue("seVerificationToken", out tokenHeaders))
            {
                var d = HashingHelper.Decrypt(tokenHeaders[0]);
                Token uiToken = JsonConvert.DeserializeObject<Token>(d);
                var result = await _authService.Deneme(uiToken);
                return Ok(result);
            }
            return Ok(new EntityResponse<AuthDto>() { ResponseCode = ResponseCodes.ValidationServiceAuthenticationError, ResponseErrorMessage = "" });
        }
    }
}