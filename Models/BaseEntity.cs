namespace piqe.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
