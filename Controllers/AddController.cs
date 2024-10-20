/*using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ebiteexample.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ebiteexample.Controllers;

public class AddController : Controller
{
    private readonly AppDbContext database;

    public AddController(AppDbContext database)
    {
        this.database = database;
    }

    //----------User----------
    public IActionResult AddUser()
    {
        return View(new User());
    }

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        if (ModelState.IsValid)
        {
            var newUser = new User
            {
                FullName = user.FullName
            };

            database.Users.Add(newUser);
            database.SaveChanges();

            return RedirectToAction("Index");
        }
        return View("Add");
    }

    //----------Device----------

    [HttpGet]
    public IActionResult SearchUser(string term)
    {
        Console.WriteLine("Searching for: " + term);
        var users = database.Users.Where(u => u.FullName.Contains(term))
            .Select(u => new {u.Id, u.FullName})
            .ToList();

        return Json(users);    
    }

    public IActionResult AddDevice()
    {
        return View(new Device());
    }

    [HttpPost]
    public IActionResult AddDevice(Device device)
    {
        if (ModelState.IsValid)
        {
            switch (device.Type)
            {
                case "Mobile":
                    var newMobile = new Mobile
                    {
                        Name = device.Name,
                        Type = device.Type,
                        Version = device.Version
                    };

                    database.Mobiles.Add(newMobile);
                    database.SaveChanges();

                    break;
                case "Computer":
                    var newComputer = new Computer
                    {
                        Name = device.Name,
                        Type = device.Type,
                        Version = device.Version
                    };

                    database.Computers.Add(newComputer);
                    database.SaveChanges();

                    break;
                case "Tablet":
                    var newTablet = new Tablet
                    {
                        Name = device.Name,
                        Type = device.Type,
                        Version = device.Version
                    };

                    database.Tablets.Add(newTablet);
                    database.SaveChanges();

                    break;
            }
            return RedirectToAction("Index");
        }
        return View("AddDevice");
    }
}
*/