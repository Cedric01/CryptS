using CryptSwitch.ApiServices;
using CryptSwitch.Authentication.Requests;
using CryptSwitch.Authentication.Responses;
using CryptSwitch.Builders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptSwitch.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest userRegistration)
        {
            var authResponse = await this.identityService.Register(userRegistration.Email, userRegistration.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.ErrorMessages
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.token
            });
        }

    }
}
