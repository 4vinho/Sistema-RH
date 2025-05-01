using IdentityServiceAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        [HttpPost("Register"), Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                var result = await accountService.Register(model);

                return result.IsSuccess ? Ok(result) : BadRequest(result);
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

                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Logout"), Authorize(Roles = "User ,Admin, Owner")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var result = await accountService.Logout();

                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpGet, Authorize]
        public IActionResult Teste()
        {
            return Ok("Hello World");
        }
    }
}
