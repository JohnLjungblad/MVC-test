using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class ManagementController : Controller
{
    private readonly AppDbContext database;

    public ManagementController(AppDbContext database)
    {
        this.database = database;
    }

    public IActionResult Add()
    {
        var viewModel = new UserDeviceViewModel
        {
            User = new User(),
            Device = new Device()
        };

        return View(viewModel);
    }

    //Device
    public IActionResult SubmitDevice(UserDeviceViewModel viewModel)
    {
        if(ModelState.IsValid)
        {
            switch(viewModel.Device.Type)
            {
                case "Mobile":

                    var existingMobileName = database.Mobiles.FirstOrDefault(e => e.Name == viewModel.Device.Name);
                    System.Console.WriteLine("In mobile switch");
                    if(existingMobileName == null)
                    {
                        Mobile newMobile = new Mobile
                        {
                            Name = viewModel.Device.Name,
                            Type = viewModel.Device.Type,
                            Version = viewModel.Device.Version,
                            UserId = viewModel.Device.UserId
                        };
                    System.Console.WriteLine("Mobile created");

                    database.Mobiles.Add(newMobile);
                    database.SaveChanges();
                }
                    break;

                case "Computer":

                var existingComputerName = database.Computers.FirstOrDefault(e => e.Name == viewModel.Device.Name);

                    if(existingComputerName == null)
                    {
                        Computer newComputer = new Computer
                        {
                            Name = viewModel.Device.Name,
                            Type = viewModel.Device.Type,
                            Version = viewModel.Device.Version,
                            UserId = viewModel.Device.UserId
                        };

                    database.Computers.Add(newComputer);
                    database.SaveChanges();
                }
                    break;

                case "Tablet":

                var existingTabletName = database.Tablets.FirstOrDefault(e => e.Name == viewModel.Device.Name);

                    if(existingTabletName == null)
                    {
                        Tablet newTablet = new Tablet
                        {
                            Name = viewModel.Device.Name,
                            Type = viewModel.Device.Type,
                            Version = viewModel.Device.Version,
                            UserId = viewModel.Device.UserId
                        };

                    database.Tablets.Add(newTablet);
                    database.SaveChanges();
                }
                    break; 
            }

            ViewBag.UserMessage = $"Device {viewModel.Device.Name} with type {viewModel.Device.Type} was submitted";
        } 
        else if(!ModelState.IsValid)
        {
            foreach(var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                System.Console.WriteLine(error.ErrorMessage);
            }
        }
        return View("Add", viewModel);
    }

    //User
    public IActionResult SubmitUser(UserDeviceViewModel viewModel)
    {
        if(ModelState.IsValid)
        {
            var existingUserName = database.Users.FirstOrDefault(n => n.FullName == viewModel.User.FullName);

            if(existingUserName == null)
            {
                User newUser = new User
                {
                    FullName = viewModel.User.FullName,
                    DepartmentId = viewModel.User.DepartmentId,
                };
            
                database.Users.Add(newUser);
                database.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("User with this name already exists");
            }
        }
        else if(!ModelState.IsValid)
        {
            foreach(var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                System.Console.WriteLine(error.ErrorMessage);
                System.Console.WriteLine("DepartmentId from frontend:" + viewModel.User.DepartmentId);
            }
        }
        return View("Add", viewModel);
    }

    //Get users to populate select element
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = database.Users.Select(u => new { u.UserId, u.FullName}).ToList();

        return Json(users);

    }

    [HttpGet]
    public IActionResult GetDepartments()
    {
        var departments = database.Departments.Select(d => new {d.DepartmentId, d.DepartmentName}).ToList();

        return Json(departments);
    }
}