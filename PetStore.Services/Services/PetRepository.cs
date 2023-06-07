using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class PetRepository : IPetRepository
    {
        private readonly PetDbContext _context;
        public PetRepository(PetDbContext context)
        {
            _context = context;
        }
        public IList<Pet> GetSomethings()
        {
            return _context.Somethings.ToList();   
        }
    }
}
