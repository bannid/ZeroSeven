﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using PetStore.Models;
using PetStore.Services;
using PetStore.WebApp.Models;
using System.Collections.Generic;
using System;
using PetStore.Services.Models;

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
            var petDtos = _petService.GetPets(pageNumber, response.ItemsPerPage);
            for(int i = 0; i < petDtos.Count; i++)
            {
                var petDto = petDtos[i];
                response.Items.Add(new PetViewModel { DateOfBirth = petDto.DateOfBirth, Name = petDto.Name, Type = petDto.Type.ToString(), Weight = petDto.Weight, ID=petDto.ID});
            }
            response.PageNumber = pageNumber;
            return View(response);
        }
        public IActionResult DeletePet(PetViewModel pet)
        {
            var petDto = new PetDto{ ID = pet.ID };
            _petService.DeletePet(petDto);
            return RedirectToAction("");
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
