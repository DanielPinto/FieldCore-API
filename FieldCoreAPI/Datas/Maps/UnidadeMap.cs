using FieldCoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FieldCoreAPI.Datas.Maps
{
    public class UnidadeMap : IEntityTypeConfiguration<UnidadeModel>
    {
        public void Configure(EntityTypeBuilder<UnidadeModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            
        }
    }
}
