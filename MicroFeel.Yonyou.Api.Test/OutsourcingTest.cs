//using MicroFeel.YongYou.Models.Models;
using MicroFeel.YongYou.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MicroFeel.Yonyou.Api.Test
{

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]

    public class OutsourcingTest
    {
        // private UFDbContext context = new UFDbContext();
        //[TestMethod]
        //public void ExpressionTest()
        //{
        //    var expression = GetExpression(a => a.ICost == 1&&a.IOrderType==2);
        //    var p = expression.Parameters;

        //    Assert.IsTrue(false);
        //}

        //public Expression<Func<OmMomain, bool>> GetExpression(Expression<Func<OmMomain,bool>> expression)
        //{
        //    return expression;
        //}
        [TestMethod]
        public void MyTestMethod()
        {
            var options = new DbContextOptionsBuilder().UseSqlServer("server=192.168.12.19;user id=sa;password=123.com;database=UFDATA_999_2019;").Options;

            using (var dbContext = new UFDbContext(options))
            {
                var materialApp = dbContext.MaterialAppVouch.FirstOrDefault(t => t.CCode == "MFAPP2020032000042");

                materialApp.MaterialAppVouchs = dbContext.MaterialAppVouchs.Where(t => t.Id == materialApp.Id).ToList();

                var dic = materialApp.MaterialAppVouchs.GroupBy(t => t.CWhCode ?? "-1").ToDictionary(t => t.Key, t => t.ToList());
                
                foreach (var key in dic.Keys)
                {
                    materialApp.MaterialAppVouchs = dic[key];
                    ;
                }

                //var results = CreateRdrecord11s(materialApp, order);
                //results.ForEach(result =>
                //{
                //    order.OrderNo = result.CCode;
                //    order.Note += result.CCode + ",";
                //    dbContext.Rdrecord11.Add(result);
                //    dbContext.Rdrecords11.AddRange(result.Rdrecords11s);
                //});

                Assert.IsTrue(materialApp.MaterialAppVouchs.Count() == 6);
            }
        }
    }
}
