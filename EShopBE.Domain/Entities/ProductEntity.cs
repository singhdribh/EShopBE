using EShopBE.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopBE.Domain.Entities
{
    [Table("Productbl")]
    public class ProductEntity:EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }    
    }
}
