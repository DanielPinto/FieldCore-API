using FieldCoreAPI.Models;

namespace FieldCoreAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        
        Task<UserModel> Add(UserModel model);
        Task<UserModel> Update(UserModel model, int id);
        Task<bool> DeleteById(int id);



    }
}
