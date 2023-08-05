using FieldCoreAPI.Models;

namespace FieldCoreAPI.Repositories.Interfaces
{
    public interface IRegionalRepository
    {
        Task<List<RegionalModel>> GetAll();
        Task<RegionalModel> GetById(int id);
        
        Task<RegionalModel> Add(RegionalModel model);
        Task<RegionalModel> Update(RegionalModel model, int id);
        Task<bool> DeleteById(int id);

    }
}
