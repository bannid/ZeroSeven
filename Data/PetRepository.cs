using PetStore.Data;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class PetRepository : IPetRepository
    {
        private readonly PetDbContext _context;
        public PetRepository(PetDbContext context)
        {
            _context = context;
        }
        public IList<PetModel> GetPets()
        {
            return _context.Pets.ToList();
        }
    }
}
