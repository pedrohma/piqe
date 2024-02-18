namespace piqe.Models;
public class Parent : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ParentType Type { get; set; }
}
