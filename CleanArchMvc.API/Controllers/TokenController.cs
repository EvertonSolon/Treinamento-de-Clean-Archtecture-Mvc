using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        public TokenController(IAuthenticate authenticate)
        {
            _authenticate = authenticate ?? 
                throw new ArgumentNullException(nameof(authenticate));
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.AuthenticateAsync(userInfo.Email, userInfo.Password);

            if (result)
            {
                //TODO
                //return GenerateToken(userInfo);

                return Ok($"User {userInfo.Email} login successfully!");
            }

            ModelState.TryAddModelError(string.Empty, "Invalid Login attempt.");
            return BadRequest(ModelState);
        }
    }
}
