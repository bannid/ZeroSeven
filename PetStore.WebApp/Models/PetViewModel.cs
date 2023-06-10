using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.WebApp.Models
{
    public class PetViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Weight { get; set; }
    }
}
