using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test1EFCoreDBFirst.Models;
using test1EFCoreDBFirst.ViewModels;

namespace test1EFCoreDBFirst.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var query = _context.Employees.Join(_context.Skills,
                            employee => employee.SkillID,
                            skill => skill.SkillID,
                            (employee, skill) => new EmployeeViewModel
                            {
                                EmployeeID = employee.EmployeeID,
                                EmployeeName = employee.EmployeeName,
                                PhoneNumber = employee.PhoneNumber,
                                Skill = skill.Title,
                                YearsExperience = employee.YearsExperience
                            });

            return View(await query.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFromDb = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills
                .FirstOrDefaultAsync(skill => skill.SkillID == employeeFromDb.SkillID);

            var employee = EmployeeProfile(employeeFromDb, skill);

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeName,PhoneNumber,SkillID,YearsExperience")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFromDb = await _context.Employees.FindAsync(id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            var skill = await _context.Skills.FindAsync(employeeFromDb.SkillID);
            var employee = EmployeeProfile(employeeFromDb, skill);

            List<Skill> skills = _context.Skills.ToList();

            ViewBag.skills = skills;

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,EmployeeName,PhoneNumber,Skill,YearsExperience")] EmployeeViewModel employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var skill = _context.Skills.Where(s => s.Title == employee.Skill).FirstOrDefault();
                    var employeeToDb = new Employee
                    {
                        EmployeeID = employee.EmployeeID,
                        EmployeeName = employee.EmployeeName,
                        PhoneNumber = employee.PhoneNumber,
                        SkillID = skill.SkillID,
                        YearsExperience = employee.YearsExperience
                    };

                    _context.Update(employeeToDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }

        private EmployeeViewModel EmployeeProfile(Employee employee, Skill skill)
        {
            return new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                EmployeeName = employee.EmployeeName,
                PhoneNumber = employee.PhoneNumber,
                Skill = skill.Title,
                YearsExperience = employee.YearsExperience
            };
        }
    }
}
