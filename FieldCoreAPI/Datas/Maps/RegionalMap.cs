using FieldCoreAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FieldCoreAPI.Datas.Maps
{
    public class RegionalMap : IEntityTypeConfiguration<RegionalModel>
    {

        public void Configure(EntityTypeBuilder<RegionalModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
        }
    }
    
    
}
