using IdentityServiceAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                var result = await accountService.Register(model);

                if (result.Success == true)
                    return Ok(result.Error);

                return BadRequest(result.Error);
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var result = await accountService.Login(model);

                if (result.Success == true)
                    return Ok(result.Error);

                return BadRequest(result.Error);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var result = await accountService.Logout();

                if (result.Success == true)
                    return Ok(result.Error);

                return BadRequest(result.Error);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
