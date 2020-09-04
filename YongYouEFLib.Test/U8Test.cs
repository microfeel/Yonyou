using MicroFeel.YonYou.EntityFrameworkCore;
using MicroFeel.YonYou.EntityFrameworkCore.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YongYouEFLib.Test
{
    [TestClass]
    public class U8Test : TestBase
    {
        private readonly U8DbContext u8context;

        public U8Test()
        {
            u8context = serviceProvider.GetRequiredService<U8DbContext>();
        }

        [TestMethod]
        public void CreateRdrecord01()
        {
            long id, detailid;
            id = detailid = -1;
            u8context.CreateRdrecord01("0000", new PuArrivalVouch(), ref id, ref detailid, "test");
        }
    }
}
