using FieldCoreAPI.Auth;
using FieldCoreAPI.Models;
using FieldCoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FieldCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        [HttpPost]
        public async Task<IActionResult> AuthAsync(string email, string password)
        {
            try
            {
                UserModel user = await _userRepository.Auth(email, password);

                if (user == null)
                {
                    return BadRequest("Password or User Error!");
                }

                var token = Token.GenerateToken(user);

                AuthModel userAuth = new AuthModel();

                userAuth.user = user;
                userAuth.token = token;
               

                return Ok(userAuth);              
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            
            

            return  BadRequest("USER OR PASSWORD INCORRECT");
        }

       
    }
}
