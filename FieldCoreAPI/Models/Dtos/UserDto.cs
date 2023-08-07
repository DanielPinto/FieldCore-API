namespace FieldCoreAPI.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Id_Corporate { get; set; }

        public List<UnidadeModel> Unidades { get; set; } = new();
    }
}
