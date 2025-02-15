using EShopBE.Domain;
using EShopBE.Domain.Entities;
using EShopBE.Graphql.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShopBE.Graphql
{
    public class FirstQuery:QueryBase
    {
        public async Task<List<ProductEntity>> MyFirstQuery([FromServices] EShopDbContext context) {

            return await context.ProductEntities.ToListAsync();
        }
    }
}
