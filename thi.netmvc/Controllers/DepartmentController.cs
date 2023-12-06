using Microsoft.AspNetCore.Mvc;
using thi.netmvc.Entities;
using thi.netmvc.Models;

namespace thi.netmvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly Datacontext _context;
        public DepartmentController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Department_Tbl> e = _context.Departments.ToList();
            return View(e);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(new Department_Tbl
                {
                   DepartmentName = model.DepartmentName,
                   DepartmentCode = model.DepartmentCode,
                   Location = model.Location,
                   Number=model.Number,
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department_Tbl user = _context.Departments.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(new DepartmentModel
            {
                DepartmentName = user.DepartmentName,
                DepartmentCode = user.DepartmentCode,
                Location = user.Location,
                Number = user.Number,
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department_Tbl model)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(new Department_Tbl
                {
                    IDepartment = model.IDepartment,
                    DepartmentName = model.DepartmentName,
                    DepartmentCode = model.DepartmentCode,
                    Location = model.Location,
                    Number = model.Number,
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Department_Tbl user = _context.Departments.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
