using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using test1EFCoreDBFirst.Models;
using test1EFCoreDBFirst.ViewModels;

namespace test1EFCoreDBFirst.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly EmployeeContext _dbContext;

        public HomeController(EmployeeContext dbContext)
        {
            //_logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var query = _dbContext.Employees.Join(_dbContext.Skills, employee => employee.SkillID, skill => skill.SkillID,
                            (employee, skill) => new EmployeeViewModel
                            {
                                EmployeeID = employee.EmployeeID,
                                EmployeeName = employee.EmployeeName,
                                PhoneNumber = employee.PhoneNumber,
                                Skill = skill.Title,
                                YearsExperience = employee.YearsExperience
                            });

            IList<EmployeeViewModel> employees = query.ToList();

            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
