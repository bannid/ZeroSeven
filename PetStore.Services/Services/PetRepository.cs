using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public void DeletePet(PetDto pet)
        {
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }

        public PetType GetPetType(int id)
        {
            return _context.PetTypes.Single(x => x.ID == id);
        }

        public PetDto GetPet(int id)
        {
            return _context.Pets.Single(x => x.ID == id);
        }

        public void UpdatePet(PetDto pet)
        {
            var local = _context.Set<PetDto>()
            .Local
            .FirstOrDefault(entry => entry.ID.Equals(pet.ID));
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(pet).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IList<PetType> GetAllPetTypes()
        {
            return _context.PetTypes.ToList();
        }

        public void AddPet(PetDto pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
        }
    }
}
