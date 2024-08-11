namespace API.Domain.Entities.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime? UpdatedDate = DateTime.UtcNow.ToLocalTime();
    }
}
