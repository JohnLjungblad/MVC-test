using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; }

    //FK
    public int DepartmentId { get; set; }


    //Nav
    public ICollection<Device>? Devices { get; set; }

    //Had to set Department as nullable because asp and/or entity is trying to validate it in creation even tho
    //its a nav property

    //Since DepartmentId isn't nullable, this should not create a problem(?)
    public Department? Department { get; set; }

}