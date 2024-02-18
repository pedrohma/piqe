namespace piqe.Models
{
    public class Teacher : BaseEntity
    {
        public string TeacherId { get; set; }
        public Guid UserId { get; set; }

        public List<Class> Classes { get; set; }
    }
}