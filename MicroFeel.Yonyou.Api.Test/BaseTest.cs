using MicroFeel.YonYou.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api.Test
{
    public class BaseTest
    {
        protected readonly U8DbContext db;

        public BaseTest()
        {
            var options = new DbContextOptionsBuilder<U8DbContext>()
                .UseSqlServer("server=192.168.12.19;user id=sa;password=123.com;database=UFDATA_001_2019;", b => b.UseRowNumberForPaging()).Options;
            db = new U8DbContext(options);
        }
    }
}
