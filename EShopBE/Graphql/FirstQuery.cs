﻿using EShopBE.Domain;
using EShopBE.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShopBE.Graphql
{
    public class FirstQuery
    {
        public async Task<List<ProductEntity>> MyFirstQuery([FromServices] EShopDbContext context) {

            return await context.ProductEntities.ToListAsync();
        }
    }
}
