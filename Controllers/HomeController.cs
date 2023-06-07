using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Models;
using PetStore.Data;

namespace PetStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPetRepository _petDbContext;
        public HomeController(ILogger<HomeController> logger, IPetRepository petDbContext)
        {
            _logger = logger;
            _petDbContext = petDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.title = "Pet list";
            return View(_petDbContext.GetPets());
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
