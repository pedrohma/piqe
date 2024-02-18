namespace piqe.Models
{
    public class Student : BaseEntity
    {
        public string StudentId {get;set;}
        public Guid UserId {get;set;}

        public virtual List<Class> Classes { get; set; }
        public virtual List<Grade> Grades {get;set;}
    }
}