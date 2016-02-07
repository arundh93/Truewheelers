using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Truewheelers.Models;
using Truewheelers.ViewModels.ShoppingCart;

namespace Truewheelers.Controllers
{
    public class ShoppingCartController : Controller
    {
        private TruewheelersDbContext _context;
        private ShoppingCartViewModel _model;
        private int test = 0;
       public ShoppingCartController(TruewheelersDbContext context, ShoppingCartViewModel model)

        {
            _model = model;
            _context = context;
        }

        // GET: ShoppingCart
        public IActionResult Index()
        {
            return View(_model);
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
        public IActionResult Create(int id)
        {
            ShoppingCart sc = new ShoppingCart();
            sc.itemID = id;
            if (_model.model == null)
                _model.model = new[] { _context.Bicycles.ToList().Single(y => y.ID == sc.itemID) };
            else
                _model.model = _model.model.Concat(new[] { _context.Bicycles.ToList().Single(y => y.ID == id) });
            if (ModelState.IsValid)
            {
                _context.ShoppingCart.Add(sc);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return Index();
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
