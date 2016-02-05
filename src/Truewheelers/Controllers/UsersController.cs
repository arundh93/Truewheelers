using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Truewheelers.Models;

namespace Truewheelers.Controllers
{
    public class UsersController : Controller
    {
        private TruewheelersDbContext _context;

        public UsersController(TruewheelersDbContext context)
        {
            _context = context;    
        }

        // GET: Users
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Users users = _context.Users.Single(m => m.ID == id);
            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(users);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Users users = _context.Users.Single(m => m.ID == id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Update(users);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Users users = _context.Users.Single(m => m.ID == id);
            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Users users = _context.Users.Single(m => m.ID == id);
            _context.Users.Remove(users);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
