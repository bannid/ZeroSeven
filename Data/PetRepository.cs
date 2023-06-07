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
        public IList<PetModel> GetPets()
        {
            IList<PetModel> pets = new List<PetModel>();

            var pet = new PetModel();
            pet.Name = "Joy";
            pet.Type = "Ferret";
            pet.DateOfBirth = DateTime.Parse("2001-05-12");
            pet.ID = "1";
            pet.Weight = 22.4;
            pets.Add(pet);
            return pets;
        }
    }
}
