using api_projeto_final.DataModels;
using api_projeto_final.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace api_projeto_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {

        private readonly ILogger<loginController> _logger;

        public loginController(ILogger<loginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> login(
            [FromServices] DbConnect context,
            [FromBody] user user
        )
        {
            if (context.users == null)
            {
                return NotFound();
            }

            user? userFound = findUserByUserName(context, user.username);
            if (userFound == null)
            {
                //StatusCode(401);
                return Unauthorized("Invalid Credentials");
            }

            authService auth = new authService();

            try
            {
                user.id = userFound.id;
                token token = auth.login(user);

                // basicamente definindo uma claim e salvar o token no cookie
                await this.saveTokenClaim(token);

                return Ok(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Error to logon: " + ex.Message);
            }
        }

        private async Task saveTokenClaim(token? token)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("token", token.token_value));
            var identity = new ClaimsIdentity(claims, "cookie");
            var userlog = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("cookie", userlog);
        }

        private user? findUserByUserName(DbConnect context, string username)
        {
            return context.users.AsNoTracking().FirstOrDefault(user => user.username == username);
        }


        [AllowAnonymous]
        [HttpGet("teste")]
        public IActionResult AccessDenied(string returnUrl = null)
        {
            // Log the error
            _logger.LogWarning("Access denied. ReturnUrl: {ReturnUrl}", returnUrl);

            // You can add additional custom logic here to handle unauthenticated requests

            return Unauthorized("Access denied. ReturnUrl:" + returnUrl);
        }

    }
}
