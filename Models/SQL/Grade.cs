namespace piqe.Models
{
    public class Grade : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Grades Grades { get; set; }
    }
}