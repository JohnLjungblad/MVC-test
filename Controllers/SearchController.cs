using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ebiteexample.Models;
using System.Linq;

namespace ebiteexample.Controllers;

public class SearchController : Controller
{

    private readonly AppDbContext database;

    public SearchController(AppDbContext database)
    {
        this.database = database;
    }

    public IActionResult Search()
    {
        return View();
    }


    [HttpGet]
    public IActionResult SearchForDevice(string searchPhrase)
    {
        var mobiles = database.Mobiles
            .Where(m => m.Name.Contains(searchPhrase))
            .Select(m => new
            {
                Type = "Mobile",
                m.Name,
                m.Version,
                m.UserId,
                m.DeviceId
            });

        var computers = database.Computers
            .Where(c => c.Name.Contains(searchPhrase))
            .Select(c => new
            {
                Type = "Computer",
                c.Name,
                c.Version,
                c.UserId,
                c.DeviceId

            });

        var tablets = database.Tablets
            .Where(t => t.Name.Contains(searchPhrase))
            .Select(t => new
            {
                Type = "Tablet",
                t.Name,
                t.Version,
                t.UserId,
                t.DeviceId
            });

        var devices = mobiles
            .Union(computers)
            .Union(tablets)
            .ToList(); 

        var listOfDevices = devices
            .Select(device => new
            {
                device.DeviceId,
                device.Type,
                device.Name,
                device.Version,
                OwnerInfo = database.Users
                    .Where(u => u.UserId == device.UserId)
                    .Select(u => new
                    {
                        FullName = u.FullName,
                        DepartmentName = database.Departments
                            .Where(d => d.DepartmentId == u.DepartmentId)
                            .Select(d => d.DepartmentName)
                            .FirstOrDefault()
                    })
                    .FirstOrDefault()
            })
            .ToList(); 

        return Json(listOfDevices);
    }
}
