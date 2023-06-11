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
    public class AddPet : Controller
    {
        private readonly ZSLogger _logger;
        private readonly IPetRepository _petService;
        private readonly PetViewModelMapper _mapper;
        public AddPet(ZSLogger logger, IPetRepository petServices, PetViewModelMapper mapper)
        {
            _logger = logger;
            _petService = petServices;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(new PetViewModel());
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PetViewModel pet)
        {
            if (_petService.GetAllPetTypes().Where(x => x.Name == pet.Type).ToList().Count == 0)
            {
                _logger.Information("Invalid pet name");
                pet.Errors.Add("Invalid pet type");
            }
            if (_petService.GetPets().Where(x => x.Name == pet.Name && x.ID != pet.ID).ToList().Count > 0)
            {
                _logger.Information("Duplicate pet name");
                pet.Errors.Add($"Pet with name {pet.Name} already exists");
            }
            try
            {
                DateTime.Parse(pet.DateOfBirth);
            }
            catch(Exception e)
            {
                _logger.Error(e, "Invalid date of birth passed to Add pet");
                pet.Errors.Add("Invalid date of birth");
            }
            if (pet.Errors.Count > 0)
            {
                return View("Index", pet);
            }
            int type = _petService.GetAllPetTypes().Single(x => x.Name == pet.Type).ID;
            try
            {
                _petService.AddPet(_mapper.MapToPetDto(pet));
            }
            catch(Exception e)
            {
                _logger.Error(e, "Add pet threw exception");
                return View("AddFail");
            }
            return View("Confirmation");
        }
    }
}
