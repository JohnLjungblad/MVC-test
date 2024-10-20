public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }

    //Nav
    public ICollection<User> Users { get; set; }
}