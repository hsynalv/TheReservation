namespace API.Domain.Entities.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime? UpdatedDate { get; set; }
    }
}
