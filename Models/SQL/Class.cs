namespace piqe.Models
{
    public class Class : BaseEntity
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public Guid TeacherKey { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}