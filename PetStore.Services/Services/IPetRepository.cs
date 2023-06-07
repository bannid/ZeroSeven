using System.Collections.Generic;
using PetStore.Services.Models;
namespace PetStore.Services
{
    public interface IPetRepository
    {
        public IList<PetDto> GetPets();
    }
}
