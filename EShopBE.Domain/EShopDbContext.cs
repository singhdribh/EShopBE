
using EShopBE.Domain.Configuration;
using EShopBE.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShopBE.Domain
{
    public class EShopDbContext:IdentityDbContext<ApplicationUserEntity, RoleUserEntity,string>
    {
        public EShopDbContext(DbContextOptions<EShopDbContext> options):base(options)
        {
                
        }
        

        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<CategoryEntity> CategoryEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureForeignKeys();
            builder.ConfigureIdentityIndexKey();
            builder.Entity<JsonFromSql>(entity => entity.HasNoKey());
            base.OnModelCreating(builder);
        }
    }
    public class JsonFromSql
    {
        public string my_json { get; set; }
    }
}
