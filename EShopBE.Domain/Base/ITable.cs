namespace EShopBE.Domain.Base
{
    public interface ITable
    {
        string CreatedBy { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        string Id { get; set; }
        bool IsDeleted { get; set; }
        string UpdatedBy { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
    }
}
