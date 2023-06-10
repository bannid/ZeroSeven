using System.Collections.Generic;
using PetStore.Services.Models;
namespace PetStore.Services
{
    public interface IPetRepository
    {
        public IList<PetDto> GetPets();
        public PetDto GetPet(int id);
        public void DeletePet(PetDto pet);
        public void UpdatePet(PetDto pet);
        public PetType GetPetType(int id);
    }
}
