namespace piqe.Models
{
    public class Student : BaseEntity
    {
        public string StudentId { get; set; }
        public Guid UserId { get; set; }

        public virtual IList<Class> Classes { get; set; }
        public virtual IList<Grade> Grades { get; set; }

        public virtual IList<Attendence> Attendence { get; set; }

    }
}