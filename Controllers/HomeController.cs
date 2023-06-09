using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using PetStore.Models;
using PetStore.Services;
using PetStore.WebApp.Models;
using System.Collections.Generic;

namespace PetStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPetRepository _petService;
        public HomeController(ILogger<HomeController> logger, IPetRepository petServices)
        {
            _logger = logger;
            _petService = petServices;
        }


        public IActionResult Index()
        {
            ViewBag.title = "Pet list";
            var petDtos = _petService.GetPets();
            IList<PetViewModel> pets = new List<PetViewModel>();
            for(int i = 0; i < petDtos.Count; i++)
            {
                var petDto = petDtos[i];
                pets.Add(new PetViewModel { DateOfBirth = petDto.DateOfBirth, Name = petDto.Name, Type = petDto.Type.ToString(), Weight = petDto.Weight, ID=petDto.ID.ToString()});
            }
            return View(pets);
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
