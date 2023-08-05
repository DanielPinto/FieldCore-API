using FieldCoreAPI.Models;

namespace FieldCoreAPI.Repositories.Interfaces
{
    public interface IUnidadeRepository
    {
        Task<List<UnidadeModel>> GetAll();
        Task<UnidadeModel> GetById(int id);
        
        Task<UnidadeModel> Add(UnidadeModel model);
        Task<UnidadeModel> Update(UnidadeModel model, int id);
        Task<bool> DeleteById(int id);

    }
}
