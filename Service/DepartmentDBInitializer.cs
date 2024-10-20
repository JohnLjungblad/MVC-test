using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentDBInitializer
{
    private readonly AppDbContext database;

    public DepartmentDBInitializer(AppDbContext database)
    {
        this.database = database;
    }

    //Temp Department table population
    public void populateDepartment()
    {
        var departments = new List<string> {"HR", "IT", "Sales"};

        foreach(var departmentName in departments)
        {
            if(!database.Departments.Any(d => d.DepartmentName == departmentName))
            {
                database.Departments.Add(new Department {DepartmentName = departmentName});
            }
        }

        database.SaveChanges();
    }
}