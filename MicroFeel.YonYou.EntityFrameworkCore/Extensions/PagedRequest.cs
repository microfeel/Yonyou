using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Extensions
{
    public class PagedRequest<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
