using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Models;
namespace PetStore.Data
{
    public interface IPetRepository
    {
        public Task<IList<PetModel>> GetPets();
    }
}
