using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using PetStore.Models;
using PetStore.Services;
using PetStore.WebApp.Models;
using System.Collections.Generic;
using System;
using PetStore.Services.Models;
using System.Linq;

namespace PetStore.Controllers
{
    public class HomeController : Controller
    {
        private int pageNumber = 1;
        private const int NUMBER_OF_ITEMS_PER_PAGE = 10;
        private readonly ILogger<HomeController> _logger;
        private readonly IPetRepository _petService;
        public HomeController(ILogger<HomeController> logger, IPetRepository petServices)
        {
            _logger = logger;
            _petService = petServices;
        }

        public IActionResult Index(string action, string page)
        {
            PagedResponseViewModel<PetViewModel> response = new PagedResponseViewModel<PetViewModel>(NUMBER_OF_ITEMS_PER_PAGE);
            response.Filter = new FilterModel();
            IList<PetDto> petDtos = _petService.GetPets()
                                    .ToList();
            int totalNumberOfPets = petDtos.Count;
            if (totalNumberOfPets == 0)
            {
                return View(response);
            }
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
            response.PageNumber = pageNumber;
            var petDtosPaginated = petDtos
                                    .Skip((response.PageNumber - 1) * response.ItemsPerPage)
                                    .Take(response.ItemsPerPage)
                                    .ToList();
            foreach (var petDto in petDtosPaginated) {
                response.Items.Add(
                    new PetViewModel { 
                        DateOfBirth = petDto.DateOfBirth,
                        Name = petDto.Name,
                        Type = _petService.GetPetType(petDto.Type).Name,
                        Weight = petDto.Weight,
                        ID=petDto.ID}
                    );
            }
            return View(response);
        }

        public IActionResult Filter(FilterModel filter)
        {
            PagedResponseViewModel<PetViewModel> response = new PagedResponseViewModel<PetViewModel>(NUMBER_OF_ITEMS_PER_PAGE);
            response.PageNumber = 1;
            response.Filter = filter;
            IList<PetDto> petDtos;
            if (filter.OrderBy == "weight") {
                petDtos = _petService
                    .GetPets()
                    .OrderBy(x => x.Weight)
                    .Where(x => filter.Type != "type" || _petService.GetPetType(x.Type).Name == filter.Value)
                    .Where(x => filter.Type != "name" || x.Name == filter.Value)
                    .ToList();
            }
            else if(filter.OrderBy == "name")
            {
                petDtos = _petService
                    .GetPets()
                    .OrderBy(x => x.Name)
                    .Where(x => filter.Type != "type" || _petService.GetPetType(x.Type).Name == filter.Value)
                    .Where(x => filter.Type != "name" || x.Name == filter.Value)
                    .ToList();
            }
            else if (filter.OrderBy == "dob")
            {
                petDtos = _petService
                    .GetPets()
                    .OrderBy(x => x.DateOfBirth)
                    .Where(x => filter.Type != "type" || _petService.GetPetType(x.Type).Name == filter.Value)
                    .Where(x => filter.Type != "name" || x.Name == filter.Value)
                    .ToList();
            }
            else
            {
                petDtos = _petService
                    .GetPets()
                    .Where(x => filter.Type != "type" || _petService.GetPetType(x.Type).Name == filter.Value)
                    .Where(x => filter.Type != "name" || x.Name == filter.Value)
                    .ToList();
            }

            int totalNumberOfPets = petDtos.Count;
            if (totalNumberOfPets == 0)
            {
                return View("Index", response);
            }
            int totalNumberOfPages = (int)Math.Ceiling((decimal)totalNumberOfPets / response.ItemsPerPage);
            response.TotalNumberOfPages = totalNumberOfPages;
            var petDtosPaginated = petDtos.Skip((response.PageNumber - 1) * response.ItemsPerPage).Take(response.ItemsPerPage).ToList();
            foreach (var petDto in petDtosPaginated)
            {
                response.Items.Add(
                    new PetViewModel
                    {
                        DateOfBirth = petDto.DateOfBirth,
                        Name = petDto.Name,
                        Type = _petService.GetPetType(petDto.Type).Name,
                        Weight = petDto.Weight,
                        ID = petDto.ID
                    }
                    );
            }
            return View("Index", response);
        }
        public IActionResult DeletePet(PetViewModel pet)
        {
            var petDto = new PetDto{ ID = pet.ID };
            _petService.DeletePet(petDto);
            return RedirectToAction("");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
