using PetStore.Services;
using PetStore.Services.Models;
using PetStore.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.WebApp.Mappers
{
    public class PetViewModelMapper
    {

        private readonly IPetRepository _petService;
        public PetViewModelMapper(IPetRepository petService)
        {
            _petService = petService;
        }
        public PetDto MapToPetDto(PetViewModel petViewModel)
        {
            return new PetDto {
                ID = petViewModel.ID,
                Name = petViewModel.Name,
                DateOfBirth = DateTime.Parse(petViewModel.DateOfBirth),
                Type = _petService.GetAllPetTypes().Single(x => x.Name == petViewModel.Type).ID,
                Weight = decimal.Parse(petViewModel.Weight),
            };
        }

        public PetViewModel MapFromPetDto(PetDto petDto)
        {
            return new PetViewModel {
                ID = petDto.ID,
                DateOfBirth = petDto.DateOfBirth.ToString(),
                Weight = petDto.Weight.ToString(),
                Type = _petService.GetPetType(petDto.Type).Name,
                Name = petDto.Name
            };
        }
    }
}
