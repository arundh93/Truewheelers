using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Truewheelers.Models;

namespace Truewheelers.Controllers
{
    public class BicyclesController : Controller
    {
        private TruewheelersDbContext _context;

        public BicyclesController(TruewheelersDbContext context)
        {
            _context = context;    
        }

        // GET: Bicycles
        public IActionResult Index()
        {
            return View(_context.Bicycles.ToList());
        }

        // GET: Bicycles/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Bicycles bicycles = _context.Bicycles.Single(m => m.ID == id);
            if (bicycles == null)
            {
                return HttpNotFound();
            }

            return View(bicycles);
        }

        // GET: Bicycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicycles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bicycles bicycles)
        {
            if (ModelState.IsValid)
            {
                _context.Bicycles.Add(bicycles);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bicycles);
        }

        // GET: Bicycles/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Bicycles bicycles = _context.Bicycles.Single(m => m.ID == id);
            if (bicycles == null)
            {
                return HttpNotFound();
            }
            return View(bicycles);
        }

        // POST: Bicycles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bicycles bicycles)
        {
            if (ModelState.IsValid)
            {
                _context.Update(bicycles);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bicycles);
        }

        // GET: Bicycles/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Bicycles bicycles = _context.Bicycles.Single(m => m.ID == id);
            if (bicycles == null)
            {
                return HttpNotFound();
            }

            return View(bicycles);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Bicycles bicycles = _context.Bicycles.Single(m => m.ID == id);
            _context.Bicycles.Remove(bicycles);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
