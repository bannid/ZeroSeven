using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Models;
using PetStore.Data;
using Microsoft.EntityFrameworkCore;

namespace PetStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PetDbContext _petDbContext;
        public HomeController(ILogger<HomeController> logger, PetDbContext petDbContext)
        {
            _logger = logger;
            _petDbContext = petDbContext;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.title = "Pet list";
            return View(await _petDbContext.Pets.ToListAsync());
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
