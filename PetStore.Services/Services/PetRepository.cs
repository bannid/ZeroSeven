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

        public IList<PetDto> GetPetsWithName(int pageNumber, int itemsPerPage, string name)
        {
            return _context.Pets
                .Where(x => x.Name == name)
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage).ToList();
        }

        public int GetNumberOfPets()
        {
            return _context.Pets.Count();
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
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }
    }
}
