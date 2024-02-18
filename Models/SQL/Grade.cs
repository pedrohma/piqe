namespace piqe.Models
{
    public class Grade : BaseEntity
    {
        public Guid StudentKey { get; set; }
        public Guid ClassKey { get; set; }
        public Grades Grades { get; set; }

        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
    }
}