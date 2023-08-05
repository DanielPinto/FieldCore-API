using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace FieldCoreAPI.Models
{
    public class UnidadeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set;}

        public List<UserModel> Users { get; set; } = new();

        public virtual RegionalModel? Regional { get; set; }

    }
}
