using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using PetStore.Models;
using PetStore.Services;
using PetStore.WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PetStore.Controllers
{
    public class HomeController : Controller
    {
        private int pageNumber = 1;
        private readonly ILogger<HomeController> _logger;
        private readonly IPetRepository _petService;
        public HomeController(ILogger<HomeController> logger, IPetRepository petServices)
        {
            _logger = logger;
            _petService = petServices;
        }

        public IActionResult Index(string action, string page)
        {
            PagedResponseViewModel<PetViewModel> response = new PagedResponseViewModel<PetViewModel>(7);
            int totalNumberOfPets = _petService.GetNumberOfPets();
            int totalNumberOfPages = (int)Math.Ceiling((decimal)totalNumberOfPets / response.ItemsPerPage);
            response.TotalNumberOfPages = totalNumberOfPages;
            try
            {
                pageNumber = page != null ? int.Parse(page) : 1;
                if (pageNumber > totalNumberOfPages)
                {
                    return RedirectToAction("");
                }

            }
            catch (Exception e)
            {
                pageNumber = 1;
            }
            var petDtos = _petService.GetPets(pageNumber, response.ItemsPerPage);
            
            IList<PetViewModel> pets = new List<PetViewModel>();
            for(int i = 0; i < petDtos.Count; i++)
            {
                var petDto = petDtos[i];
                pets.Add(new PetViewModel { DateOfBirth = petDto.DateOfBirth, Name = petDto.Name, Type = petDto.Type.ToString(), Weight = petDto.Weight, ID=petDto.ID.ToString()});
            }
            response.PageNumber = pageNumber;
            response.Items = pets;
            return View(response);
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
