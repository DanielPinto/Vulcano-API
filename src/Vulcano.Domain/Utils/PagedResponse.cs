using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vulcano.Domain.Utils
{
    public class PagedResponse<T>(IEnumerable<T> data, int currentPage, int totalItems, int pageSize)
    {
        public IEnumerable<T> Data { get; set; } = data;
        public int CurrentPage { get; set; } = currentPage;
        public int TotalItems { get; set; } = totalItems;
        public int TotalPages { get; set; } = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
}