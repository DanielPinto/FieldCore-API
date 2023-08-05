namespace FieldCoreAPI.Models
{
    public class RegionalModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }

        public List<UnidadeModel>? Unidades { get; set; }
    }
}
