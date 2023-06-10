using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetStore.Services;
using PetStore.Services.Models;
using PetStore.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.WebApp.Controllers
{
    public class EditPet : Controller
    {
        private readonly ILogger<EditPet> _logger;
        private readonly IPetRepository _petService;
        public EditPet(ILogger<EditPet> logger, IPetRepository petServices)
        {
            _logger = logger;
            _petService = petServices;
        }
        public IActionResult Index(string action, int id)
        {
            var petDto = _petService.GetPet(id);
            var pet = new PetViewModel { 
                Name = petDto.Name,
                DateOfBirth = petDto.DateOfBirth,
                ID = petDto.ID,
                Weight = petDto.Weight,
                Type = _petService.GetPetType(petDto.Type).Name };
            return View(pet);
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(PetViewModel pet)
        {
            _petService.UpdatePet(new PetDto { ID = pet.ID, DateOfBirth = pet.DateOfBirth, Name = pet.Name, Type = 4, Weight = pet.Weight });
            return View("Confirmation");
        }
    }
}
