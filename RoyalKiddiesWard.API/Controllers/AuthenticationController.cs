using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalKiddiesWard.API.ViewModels;
using RoyalKiddiesWard.Application.Services.Interfaces;

namespace RoyalKiddiesWard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<ActionResult> Login([FromBody] UserLogin userLogin)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            //check if a user exists with the provided email and password
            var user = await _userService.AuthenticateUser(userLogin.Email,
                userLogin.Password);

            if (user is null)
            {
                return this.Problem("email or password is incorrect", statusCode: 400);
            }

            //get roles 
            var roles = await _userService.GetRolesByUser(user);

            //generate a jwt token
            var token = _tokenService.GenerateToken(user, roles);

            //return token in the response
            return Ok(new { Token = token });
        }
        
    }
}
