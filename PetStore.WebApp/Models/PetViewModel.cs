using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.WebApp.Models
{
    public class PetViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DateOfBirth { get; set; }
        public string Weight { get; set; }
        public IList<string> Errors { get; set; }
        public PetViewModel()
        {
            Errors = new List<string>();
        }
    }
}
