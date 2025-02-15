using Microsoft.AspNetCore.Identity;

namespace EShopBE.Domain.Entities
{
    public class RoleUserEntity : IdentityRole
    {
        public RoleUserEntity()
        {

        }
        public RoleUserEntity(string roleName) : base(roleName)
        {

        }

     
    }
}
