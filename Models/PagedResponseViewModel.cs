using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.WebApp.Models
{
    public class PagedResponseViewModel<T>
    {
        public int ItemsPerPage { get; set; } = 10;
        public PagedResponseViewModel() { }
        public PagedResponseViewModel(int itemsPerPage)
        {
            ItemsPerPage = itemsPerPage;
        }
        public int TotalNumberOfPages { get; set; }
        public int PageNumber { get; set; }
        public IList<T> Items { get; set; }
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
