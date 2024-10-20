using System.ComponentModel.DataAnnotations;

public class Device
{
    [Key]
    public int DeviceId { get; set; }
    public  string Name { get; set; }
    public  string Type { get; set; }
    public  string Version { get; set; }

    //FK
    public int UserId { get; set; }
    public User? User { get; set; }   
}

public class Mobile : Device
{
    
}

public class Computer : Device
{

}

public class Tablet : Device
{

}