using Microsoft.AspNetCore.Identity;

namespace EShopBE.Domain.Entities
{
    public class ApplicationUserEntity : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDisabled { get; set; }
      


    }
}
