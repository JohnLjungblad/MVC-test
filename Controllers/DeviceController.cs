using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

public class DeviceController : Controller
{
    private readonly AppDbContext database;

    public DeviceController(AppDbContext database)
    {
        this.database = database;
    }

    public IActionResult DeviceDetails()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DeviceDetails(int id,string type, string name, string version, string ownerFullName, string departmentName)
    {
        
        var deviceDetails = new
        {
            Id = id,
            Type = type,
            Name = name,
            Version = version,
            OwnerFullName = ownerFullName,
            DepartmentName = departmentName
        };
        return View(deviceDetails); 
    }


    [HttpPost]
    public IActionResult UpdateDevice(int id, string type, string name, string version, int userId, string departmentName)
    {
        switch (type)
        {
            case "Mobile":
                var mobileToUpdate = database.Mobiles
                    .Where(m => m.DeviceId == id).FirstOrDefault();
                if(mobileToUpdate != null)
                {
                    mobileToUpdate.Name = name;
                    mobileToUpdate.Version = version;


                    mobileToUpdate.UserId = userId;
                }
                break;

            case "Computer":
                var computerToUpdate = database.Computers
                    .Where(c => c.DeviceId == id).FirstOrDefault();

                if(computerToUpdate != null)
                {
                    computerToUpdate.Name = name;
                    computerToUpdate.Version = version;

                    computerToUpdate.UserId = userId;
                }
                break;

            case "Tablet":
                var tabletToUpdate = database.Tablets
                    .Where(t => t.DeviceId == id).FirstOrDefault();

                if(tabletToUpdate != null)
                {
                    tabletToUpdate.Name = name;
                    tabletToUpdate.Version = version;

                    tabletToUpdate.UserId = userId;
                }
                break;
        }


        database.SaveChanges();

        return Ok();
    }

}
