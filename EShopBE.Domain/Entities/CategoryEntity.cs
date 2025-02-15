using EShopBE.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopBE.Domain.Entities
{
    [Table("CategoryTbl")]
    public class CategoryEntity:EntityBase
    {
        public string CategoryName { get; set; }
        public virtual ICollection<ProductEntity> ProductEntities { get; set; }

    }
}
