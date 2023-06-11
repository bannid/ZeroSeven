using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetStore.Services;
using PetStore.Services.Models;
using PetStore.WebApp.Mappers;
using PetStore.WebApp.Models;
using System;
using System.Linq;

namespace PetStore.WebApp.Controllers
{
    public class EditPet : Controller
    {
        private readonly ZSLogger _logger;
        private readonly IPetRepository _petService;
        private readonly PetViewModelMapper _mapper;
        public EditPet(ZSLogger logger, IPetRepository petServices, PetViewModelMapper mapper)
        {
            _logger = logger;
            _petService = petServices;
            _mapper = mapper;
        }
        public IActionResult Index(string action, int id)
        {
            try
            {
                var petDto = _petService.GetPet(id);
                var pet = _mapper.MapFromPetDto(petDto);
                return View(pet);
            } 
            catch(Exception e)
            {
                _logger.Error(e,"Pet with {@id} not found", id);
                return View("NotFound");
            }
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(PetViewModel pet)
        {
            if (_petService.GetAllPetTypes().Where(x => x.Name == pet.Type).ToList().Count == 0)
            {
                _logger.Information("Invalid pet type passed to Update pet function");
                pet.Errors.Add("Invalid pet type");
            }
            if (_petService.GetPets().Where(x => x.Name == pet.Name && x.ID != pet.ID).ToList().Count > 0)
            {
                _logger.Information("Duplicte pet name passed to Update pet");
                pet.Errors.Add($"Pet with name {pet.Name} already exists");
            }
            if (pet.Errors.Count > 0)
            {
                return View("Index", pet);
            }
            int type = _petService.GetAllPetTypes().Single(x => x.Name == pet.Type).ID;
            try
            {
                _petService.UpdatePet(_mapper.MapToPetDto(pet));
            }
            catch(Exception e)
            {
                _logger.Error(e, "Update pet failed");
                return View("UpdateFail");
            }
            return View("Confirmation");
        }
    }
}
