using System.Collections.Generic;
using PetStore.Services.Models;
namespace PetStore.Services
{
    public interface IPetRepository
    {
        public IList<PetDto> GetPets(int pageNumber, int itemsPerPage);
        public IList<PetDto> GetPetsAll();
        public int GetNumberOfPets();
        public void DeletePet(PetDto pet);
    }
}
