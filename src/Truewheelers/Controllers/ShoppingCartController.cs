using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Truewheelers.Models;

namespace Truewheelers.Controllers
{
    public class ShoppingCartController : Controller
    {
        private TruewheelersDbContext _context;

        public ShoppingCartController(TruewheelersDbContext context)
        {
            _context = context;    
        }

        // GET: ShoppingCart
        public IActionResult Index()
        {
            return View(_context.ShoppingCart.ToList());
        }

        // GET: ShoppingCart/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ShoppingCart shoppingCart = _context.ShoppingCart.Single(m => m.ID == id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _context.ShoppingCart.Add(shoppingCart);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCart/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ShoppingCart shoppingCart = _context.ShoppingCart.Single(m => m.ID == id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCart/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _context.Update(shoppingCart);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCart/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ShoppingCart shoppingCart = _context.ShoppingCart.Single(m => m.ID == id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }

            return View(shoppingCart);
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ShoppingCart shoppingCart = _context.ShoppingCart.Single(m => m.ID == id);
            _context.ShoppingCart.Remove(shoppingCart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}