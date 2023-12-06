using Microsoft.AspNetCore.Mvc;
using thi.netmvc.Entities;
using thi.netmvc.Models;

namespace thi.netmvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Datacontext _context;
        public EmployeeController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Employee_Tbl> e = _context.Employees.ToList();
            return View(e);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(new Employee_Tbl 
                {
                   EmployeeName = model.EmployeeName,
                   IdUser = model.IdUser,
                   IDepartment = model.IDepartment,
                    Rank = model.Rank,
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee_Tbl user = _context.Employees.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(new EmployeeModel
            {
                EmployeeName = user.EmployeeName,
                IdUser = user.IdUser,
                IDepartment = user.IDepartment,
                Rank = user.Rank,
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee_Tbl model)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(new Employee_Tbl
                {
                    EmployeeCode = model.EmployeeCode,
                    EmployeeName = model.EmployeeName,
                    IdUser = model.IdUser,
                    IDepartment = model.IDepartment,
                    Rank = model.Rank,
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Employee_Tbl user = _context.Employees.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
