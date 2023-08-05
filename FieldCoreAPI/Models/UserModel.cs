using System.ComponentModel.DataAnnotations;

namespace FieldCoreAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Id_Corporate { get; set; }

        public List<UnidadeModel> Unidades { get; set; } = new();
     }
}
