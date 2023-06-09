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

        public IList<PetDto> GetPets(int pageNumber, int itemsPerPage)
        {
            return _context.Pets.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();
        }

        public IList<PetDto> GetPetsAll()
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfPets()
        {
            return _context.Pets.Count();
        }
    }
}
