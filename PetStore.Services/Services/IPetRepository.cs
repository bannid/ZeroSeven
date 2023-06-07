using System.Collections.Generic;

namespace PetStore.Services
{
    public interface IPetRepository
    {
        public IList<Pet> GetSomethings();
    }
}
