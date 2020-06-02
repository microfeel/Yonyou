using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Extensions
{
    public class PagedResult<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Results { get; set; } = new List<T>();

        public PagedResult(int totalCount,IEnumerable<T> source)
        {
            TotalCount = totalCount;
            Results = source.ToList();
        }
    }
}
