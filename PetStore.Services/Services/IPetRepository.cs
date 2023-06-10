using System.Collections.Generic;
using PetStore.Services.Models;
namespace PetStore.Services
{
    public interface IPetRepository
    {
        public IList<PetDto> GetPets(int pageNumber, int itemsPerPage);
        public PetDto GetPet(int id);
        public IList<PetDto> GetPetsWithName(int pageNumber, int itemsPerPage, string name);
        public IList<PetDto> GetPetsAll();
        public int GetNumberOfPets();
        public void DeletePet(PetDto pet);
        public void UpdatePet(PetDto pet);
        public PetType GetPetType(int id);
    }
}
