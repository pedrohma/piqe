namespace piqe.Models
{
    public class Attendence : BaseEntity
    {
        public Guid StudentKey { get; set; }
        public bool IsPresent { get; set; }
        public string NotAttendingReason { get; set; }
        public virtual Student Student { get; set; }
    }
}