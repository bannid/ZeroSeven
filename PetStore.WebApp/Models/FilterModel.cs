using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.WebApp.Models
{
    public class FilterModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string OrderBy { get; set; }
    }
}
