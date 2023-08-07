using FieldCoreAPI.Models;
using FieldCoreAPI.Models.Dtos;

namespace FieldCoreAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAll();
        Task<UserModel> GetById(int id);

        Task<UserModel> Auth(string email, string password);

        Task<UserModel> Add(UserModel model);
        Task<UserModel> Update(UserModel model, int id);
        Task<bool> DeleteById(int id);



    }
}
