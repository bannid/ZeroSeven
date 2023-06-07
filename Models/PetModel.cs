using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class PetModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
    }
}
