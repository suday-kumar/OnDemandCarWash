using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWash_BAL.Services;
using CarWash_DAL.Data;
using CarWash_DAL.JWT;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace CarWashWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginService;
        private readonly JwtHandler _jwtHandler;
        public LoginController(LoginService loginservice, JwtHandler jwtHandler)
        {
            loginService = loginservice;
            _jwtHandler = jwtHandler;
        }
        [HttpPost("CustomerLogin")]
        public async Task<IActionResult> CustomerLogin([FromBody] Login login)
        {
            try
            {
                var user = await loginService.CustomerLogin(login);
                if (user == null)
                    return Unauthorized(new LoginDto { ErrorMessage = "Invalid Authentication" });
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = _jwtHandler.GetClaims(login);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new LoginDto { IsAuthSuccessful = true, Token = token, UserId = user.UserId, UserFirstName = user.UserFirstName });
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpPost("WasherLogin")]
        public async Task<IActionResult> WasherLogin([FromBody] Login login)
        {
            try
            {
                var user = await loginService.WasherLogin(login);
                if (user == null)
                    return Unauthorized(new LoginDto { ErrorMessage = "Invalid Authentication" });
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = _jwtHandler.GetClaims(login);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new LoginDto { IsAuthSuccessful = true, Token = token, UserId = user.UserId, UserFirstName = user.UserFirstName });
            }
            catch (Exception)
            {
                throw;
            }
           }
    }
}
