using EShopBE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopBE.Domain.Configuration
{
    public static class ForeignKeyModelBuilders
    {
        public static void ConfigureForeignKeys(this ModelBuilder builder)
        {
            builder.Entity<ProductEntity>().HasOne(p => p.Category).WithMany(p => p.ProductEntities);

        }
    }
}
