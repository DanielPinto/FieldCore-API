using FieldCoreAPI.Models;
using FieldCoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FieldCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        [HttpGet]
        public async  Task<ActionResult<List<UserModel>>> ListAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAll();
            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel userFound = await _userRepository.GetById(id);
            return Ok(userFound);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Add([FromBody] UserModel user)
        {
            UserModel userAdded = await _userRepository.Add(user);
            return Ok(userAdded);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel user, int id) 
        {
            UserModel userUpdated = await _userRepository.Update(user,id);
            return Ok(userUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteById(int id)
        {
            bool successDeleted = await _userRepository.DeleteById(id);
            return Ok(successDeleted);
        }

    }
}
