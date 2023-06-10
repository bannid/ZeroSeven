using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.WebApp.Models
{
    public class PagedResponseViewModel<T>
    {
        public int ItemsPerPage { get; set; } = 10;
        public IList<T> Items { get; set; }
        public FilterModel Filter { get; set; }
        public PagedResponseViewModel() {
            this.Items = new List<T>();
        }
        public PagedResponseViewModel(int itemsPerPage)
        {
            ItemsPerPage = itemsPerPage;
            this.Items = new List<T>();
        }
        public int TotalNumberOfPages { get; set; }
        public int PageNumber { get; set; }
        public int GetNextPage()
        {
            if (PageNumber < TotalNumberOfPages)
            {
                return PageNumber + 1;
            }
            return -1;
        }
        public int GetPreviousPage()
        {
            return Math.Max(1, PageNumber - 1);
        }
    }
}
