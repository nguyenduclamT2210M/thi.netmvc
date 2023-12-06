using Microsoft.AspNetCore.Mvc;
using thi.netmvc.Entities;
using thi.netmvc.Models;

namespace thi.netmvc.Controllers
{
    public class UserController : Controller
    {
        private readonly Datacontext _context;
        public UserController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<User> users = _context.Users.ToList();
            return View(users);
        }
       public IActionResult Create()
       {
            return View();
       }
        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    Tel = model.Tel
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = _context.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return View(new UserModel
            {
                UserId =user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Tel = user.Tel
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(new User
                {
                    UserId =model.UserId,
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    Tel = model.Tel
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            User user = _context.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
