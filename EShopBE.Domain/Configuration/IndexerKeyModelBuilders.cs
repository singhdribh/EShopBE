using EShopBE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopBE.Domain.Configuration
{
    public static class IndexerKeyModelBuilders
    {
        public static void ConfigureIdentityIndexKey(this ModelBuilder builder)
        {
            builder.Entity<ProductEntity>().HasKey(x => x.Id).IsClustered(false);
            builder.Entity<ProductEntity>().HasIndex(x => x.CreatedAt).IsUnique(true).IsClustered();
         
            builder.Entity<CategoryEntity>().HasKey(x => x.Id).IsClustered(false);
            builder.Entity<CategoryEntity>().HasIndex(x => x.CreatedAt).IsUnique(true).IsClustered();


        }
    }
}
