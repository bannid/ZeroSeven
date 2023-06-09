using System;

namespace PetStore.Services.Models
{
    
    public class PetDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Weight { get; set; }
    }
}
