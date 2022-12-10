using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        //public IActionResult Index()
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Items.ToListAsync());
        //    //return View();
        //}

        //Search:Items
        public async Task<IActionResult> Index(string? SearchString)
        {
            if (_context.Items == null)
            {return Problem("Entity set is null.");}
            var item = from m in _context.Items
                       select m;
            if (!String.IsNullOrEmpty(SearchString))
            {item = item.Where(s => s.Name!.Contains(SearchString));}
            return View(await item.ToListAsync());
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