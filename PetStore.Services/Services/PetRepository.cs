using System.Collections.Generic;
using System.Linq;
using PetStore.Services.Data;
using PetStore.Services.Models;
namespace PetStore.Services
{
    public class PetRepository : IPetRepository
    {
        private readonly PetDbContext _context;
        public PetRepository(PetDbContext context)
        {
            _context = context;
        }
        public IList<PetDto> GetPets()
        {
            return _context.Pets.ToList();   
        }
    }
}
