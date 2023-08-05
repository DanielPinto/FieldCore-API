using FieldCoreAPI.Datas.Maps;
using FieldCoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FieldCoreAPI.Datas
{
    public class FieldCoreAPIDBContext:DbContext
    {
        public FieldCoreAPIDBContext(DbContextOptions<FieldCoreAPIDBContext> options):base(options) { }
        
        public DbSet<UserModel>? Users { get; set; }
        public DbSet<UnidadeModel>? Unidades { get; set; }

        public DbSet<RegionalModel>? Regionais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.ApplyConfiguration(new UnidadeMap());

            modelBuilder.ApplyConfiguration(new RegionalMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
