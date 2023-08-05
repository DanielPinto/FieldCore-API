using FieldCoreAPI.Models;
using FieldCoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FieldCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly IUnidadeRepository _repository;

        public UnidadeController(IUnidadeRepository repository)
        {
            _repository = repository;
            
        }

        [HttpGet]
        public async  Task<ActionResult<List<UnidadeModel>>> ListAllUsers()
        {
            List<UnidadeModel> users = await _repository.GetAll();
            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeModel>> GetById(int id)
        {
            UnidadeModel userFound = await _repository.GetById(id);
            return Ok(userFound);
        }

        [HttpPost]
        public async Task<ActionResult<UnidadeModel>> Add([FromBody] UnidadeModel unidade)
        {
            UnidadeModel userAdded = await _repository.Add(unidade);
            return Ok(userAdded);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UnidadeModel>> Update([FromBody] UnidadeModel user, int id) 
        {
            UnidadeModel userUpdated = await _repository.Update(user,id);
            return Ok(userUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteById(int id)
        {
            bool successDeleted = await _repository.DeleteById(id);
            return Ok(successDeleted);
        }

    }
}
