﻿//using MicroFeel.YongYou.Models.Models;
using MicroFeel.YonYou.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Linq;

namespace MicroFeel.Yonyou.Api.Test
{

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]

    public class OutsourcingTest : BaseTest
    {
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
        public void getOmOrders()
        {
            var orders = db.GetPurchaseOrders(
                "委外加工",
                "柏瑞美",
                "",
                "",
                "开立",
                null,
                null,
                0,
                40);
            foreach (var order in orders.Results)
            {
                System.Console.WriteLine($"code: {order.Ccode}");
            }
            //var materialApp = db.MaterialAppVouch.FirstOrDefault(t => t.CCode == "MFAPP2020032000042");

            //materialApp.MaterialAppVouchs = db.MaterialAppVouchs.Where(t => t.Id == materialApp.Id).ToList();

            //var dic = materialApp.MaterialAppVouchs.GroupBy(t => t.CWhCode ?? "-1").ToDictionary(t => t.Key, t => t.ToList());

            //foreach (var key in dic.Keys)
            //{
            //    materialApp.MaterialAppVouchs = dic[key];
            //    ;
            //}

            //var results = CreateRdrecord11s(materialApp, order);
            //results.ForEach(result =>
            //{
            //    order.OrderNo = result.CCode;
            //    order.Note += result.CCode + ",";
            //    dbContext.Rdrecord11.Add(result);
            //    dbContext.Rdrecords11.AddRange(result.Rdrecords11s);
            //});

            //Assert.IsTrue(materialApp.MaterialAppVouchs.Count() == 6);
        }
    }
}
