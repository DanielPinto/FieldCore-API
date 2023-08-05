using FieldCoreAPI.Models;
using FieldCoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FieldCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionalController : ControllerBase
    {
        private readonly IRegionalRepository _repository;

        public RegionalController(IRegionalRepository repository)
        {
            _repository = repository;
            
        }

        [HttpGet]
        public async  Task<ActionResult<List<RegionalModel>>> GetAll()
        {
            List<RegionalModel> list = await _repository.GetAll();
            return Ok(list);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegionalModel>> GetById(int id)
        {
            RegionalModel itemFound = await _repository.GetById(id);
            return Ok(itemFound);
        }

        [HttpPost]
        public async Task<ActionResult<RegionalModel>> Add([FromBody] RegionalModel item)
        {
            RegionalModel itemAdded = await _repository.Add(item);
            return Ok(itemAdded);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RegionalModel>> Update([FromBody] RegionalModel item, int id) 
        {
            RegionalModel itemUpdated = await _repository.Update(item, id);
            return Ok(itemUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteById(int id)
        {
            bool successDeleted = await _repository.DeleteById(id);
            return Ok(successDeleted);
        }

    }
}
