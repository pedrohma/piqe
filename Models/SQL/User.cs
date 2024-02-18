namespace piqe.Models
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public UserType UserType { get; set; }
        public UserAccessLevel AccessLevel { get; set; }
        public Guid? TeacherKey { get; set; }
        public Guid? StudentKey { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}