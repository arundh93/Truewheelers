using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Truewheelers.ViewModels;
using Truewheelers.Models;

namespace Truewheelers.Controllers
{
    public class HomeController : Controller
    {

        private TruewheelersDbContext _context;
        private HomeViewModel _model;

        public HomeController(TruewheelersDbContext context, HomeViewModel model)
        {
            _model = model;
            _context = context;
        }
        public IActionResult Index()
        {
            _model.model = _context.Bicycles.ToList();
            return View(_model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
