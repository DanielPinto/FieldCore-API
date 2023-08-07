using FieldCoreAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace FieldCoreAPI.Services
{
    public class UserServices
    {
        
        public UserModel RemovePassword(UserModel user)
        {

            UserModel userWithoutPassword = new()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Id_Corporate = user.Id_Corporate,
                Unidades = user.Unidades,
            };

            return userWithoutPassword;

        }
    }
}
