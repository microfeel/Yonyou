﻿using MicroFeel.Yonyou.Api.Model.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public class BasicApiTest : ApiTest
    {
        [TestMethod]
        public async Task GetPersonAsync()
        {
            var api = new BasicApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Batch_Get_PersonAsync();
            Assert.IsNotNull(result);
            System.Console.WriteLine($"batch_get_personasync is :{result}");
        }

        [TestMethod]
        public async Task GetPersontypeAsync()
        {
            var api = new BasicApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Batch_Get_PersontypeAsync();
            Assert.IsNotNull(result);
            System.Console.WriteLine($"batch_get_persontype is :{result}");
        }

        [TestMethod]
        public void Testjson()
        {
            var s = "{\"rows_per_page\":\"20\",\"errcode\":\"0\",\"errmsg\":\"\",\"page_count\":\"12\",\"row_count\":\"223\",\"page_index\":\"1\",\"person\":[{\"row_count\":\"223\",\"RowNum\":\"1\",\"code\":\"BG637\",\"name\":\"孙越\",\"cuser_id\":\"BG637\",\"cuser_name\":\"孙越\",\"cdept_num\":\"100101\",\"cdept_name\":\"高柏诗销售部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"230121200104291022\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"17645141461\",\"cjobcode\":\"066\",\"vjobname\":\"黑龙江美导\",\"bpsnperson\":\"1\",\"dBirthDate\":\"2001-04-29\",\"timestamp\":\"518.5726\"},{\"row_count\":\"223\",\"RowNum\":\"2\",\"code\":\"GA001\",\"name\":\"王治倞\",\"cuser_id\":\"GA001\",\"cuser_name\":\"王治倞\",\"cdept_num\":\"01\",\"cdept_name\":\"总经办\",\"rsex\":\"1\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"230103197007082416\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13823069652\",\"cjobcode\":\"001\",\"vjobname\":\"总经理\",\"bpsnperson\":\"1\",\"timestamp\":\"522.1181\"},{\"row_count\":\"223\",\"RowNum\":\"3\",\"code\":\"GA002\",\"name\":\"魏凤霞\",\"cuser_id\":\"GA002\",\"cuser_name\":\"魏凤霞\",\"cdept_num\":\"01\",\"cdept_name\":\"总经办\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"230107197306112641\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13726212790\",\"cjobcode\":\"001\",\"vjobname\":\"总经理\",\"bpsnperson\":\"1\",\"timestamp\":\"522.1200\"},{\"row_count\":\"223\",\"RowNum\":\"4\",\"code\":\"GA027\",\"name\":\"曾莉\",\"cuser_id\":\"GA027\",\"cuser_name\":\"曾莉\",\"cdept_num\":\"02\",\"cdept_name\":\"财务部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"511224198305188286\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13680370079\",\"cjobcode\":\"059\",\"vjobname\":\"成本会计\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1983-05-18\",\"timestamp\":\"525.5003\"},{\"row_count\":\"223\",\"RowNum\":\"5\",\"code\":\"GA032\",\"name\":\"张想\",\"cuser_id\":\"GA032\",\"cuser_name\":\"张想\",\"cdept_num\":\"0802\",\"cdept_name\":\"材料仓\",\"rsex\":\"1\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"430221198907085313\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"15913395314\",\"cjobcode\":\"016\",\"vjobname\":\"材料仓主管\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1989-07-08\",\"timestamp\":\"525.5857\"},{\"row_count\":\"223\",\"RowNum\":\"6\",\"code\":\"GA037\",\"name\":\"邓安平\",\"cuser_id\":\"GA037\",\"cuser_name\":\"邓安平\",\"cdept_num\":\"04\",\"cdept_name\":\"信息技术部\",\"rsex\":\"1\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"500235198609164116\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13424574865\",\"cjobcode\":\"065\",\"vjobname\":\"信息技术经理\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1986-09-16\",\"timestamp\":\"525.5704\"},{\"row_count\":\"223\",\"RowNum\":\"7\",\"code\":\"GA072\",\"name\":\"郭珊霞\",\"cuser_id\":\"GA072\",\"cuser_name\":\"郭珊霞\",\"cdept_num\":\"100103\",\"cdept_name\":\"高柏诗商务部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"430725199003267445\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"15819438730\",\"cjobcode\":\"040\",\"vjobname\":\"高柏诗商务文员\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1990-03-26\",\"timestamp\":\"6664.8428\"},{\"row_count\":\"223\",\"RowNum\":\"8\",\"code\":\"GA075\",\"name\":\"孙海江\",\"cuser_id\":\"GA075\",\"cuser_name\":\"孙海江\",\"cdept_num\":\"05\",\"cdept_name\":\"产品研发部\",\"rsex\":\"1\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"130302197807011852\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13825089266\",\"cjobcode\":\"003\",\"vjobname\":\"研发经理\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1978-07-01\",\"timestamp\":\"525.5719\"},{\"row_count\":\"223\",\"RowNum\":\"9\",\"code\":\"GA118\",\"name\":\"蒲正军\",\"cuser_id\":\"GA118\",\"cuser_name\":\"蒲正军\",\"cdept_num\":\"0801\",\"cdept_name\":\"品控部\",\"rsex\":\"1\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"620503197912118014\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"15015955169\",\"cjobcode\":\"010\",\"vjobname\":\"品控仓储经理\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1979-12-11\",\"timestamp\":\"525.5829\"},{\"row_count\":\"223\",\"RowNum\":\"10\",\"code\":\"GA121\",\"name\":\"李祖会\",\"cuser_id\":\"GA121\",\"cuser_name\":\"李祖会\",\"cdept_num\":\"03\",\"cdept_name\":\"人事行政部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"519002196204107204\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13658138497\",\"cjobcode\":\"062\",\"vjobname\":\"清洁工\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1962-04-10\",\"timestamp\":\"518.5558\"},{\"row_count\":\"223\",\"RowNum\":\"11\",\"code\":\"GA130\",\"name\":\"黎贵香\",\"cuser_id\":\"GA130\",\"cuser_name\":\"黎贵香\",\"cdept_num\":\"0801\",\"cdept_name\":\"品控部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"430702197809190068\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"15992618813\",\"cjobcode\":\"011\",\"vjobname\":\"品控主管\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1978-09-19\",\"timestamp\":\"525.5843\"},{\"row_count\":\"223\",\"RowNum\":\"12\",\"code\":\"GA162\",\"name\":\"李林丽\",\"cuser_id\":\"GA162\",\"cuser_name\":\"李林丽\",\"cdept_num\":\"02\",\"cdept_name\":\"财务部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"450323198909242724\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"15089155632\",\"cjobcode\":\"055\",\"vjobname\":\"财务主管\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1989-09-24\",\"timestamp\":\"525.5015\"},{\"row_count\":\"223\",\"RowNum\":\"13\",\"code\":\"GA209\",\"name\":\"陈令凤\",\"cuser_id\":\"GA209\",\"cuser_name\":\"陈令凤\",\"cdept_num\":\"0801\",\"cdept_name\":\"品控部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"411528198904202009\",\"rEmployState\":\"10\",\"cjobcode\":\"015\",\"vjobname\":\"车间品检员\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1989-04-20\",\"timestamp\":\"518.6143\"},{\"row_count\":\"223\",\"RowNum\":\"14\",\"code\":\"GA222\",\"name\":\"石春梅\",\"cuser_id\":\"GA222\",\"cuser_name\":\"石春梅\",\"cdept_num\":\"100103\",\"cdept_name\":\"高柏诗商务部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"452122198803062746\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13680131011\",\"cjobcode\":\"039\",\"vjobname\":\"高柏诗商务主管\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1988-03-06\",\"timestamp\":\"525.6127\"},{\"row_count\":\"223\",\"RowNum\":\"15\",\"code\":\"GA224\",\"name\":\"袁少兰\",\"cuser_id\":\"GA224\",\"cuser_name\":\"袁少兰\",\"cdept_num\":\"0805\",\"cdept_name\":\"退货仓\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"430425197103022167\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13112378590\",\"cjobcode\":\"026\",\"vjobname\":\"退货员\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1971-03-02\",\"timestamp\":\"518.6159\"},{\"row_count\":\"223\",\"RowNum\":\"16\",\"code\":\"GA232\",\"name\":\"郑琼珠\",\"cuser_id\":\"GA232\",\"cuser_name\":\"郑琼珠\",\"cdept_num\":\"100203\",\"cdept_name\":\"柏瑞美商务部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"440582199205206163\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13242218745\",\"cjobcode\":\"051\",\"vjobname\":\"柏瑞美商务主管\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1992-05-20\",\"timestamp\":\"525.6763\"},{\"row_count\":\"223\",\"RowNum\":\"17\",\"code\":\"GA233\",\"name\":\"李春霞\",\"cuser_id\":\"GA233\",\"cuser_name\":\"李春霞\",\"cdept_num\":\"05\",\"cdept_name\":\"产品研发部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"452124198807281527\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"15818952506\",\"cjobcode\":\"005\",\"vjobname\":\"研发文员\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1988-07-28\",\"timestamp\":\"518.5578\"},{\"row_count\":\"223\",\"RowNum\":\"18\",\"code\":\"GA241\",\"name\":\"杨葆春\",\"cuser_id\":\"GA241\",\"cuser_name\":\"杨葆春\",\"cdept_num\":\"03\",\"cdept_name\":\"人事行政部\",\"rsex\":\"1\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"610125197510177139\",\"rEmployState\":\"10\",\"cjobcode\":\"064\",\"vjobname\":\"行政经理\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1975-10-17\",\"timestamp\":\"525.5654\"},{\"row_count\":\"223\",\"RowNum\":\"19\",\"code\":\"GA250\",\"name\":\"李春霞\",\"cuser_id\":\"GA250\",\"cuser_name\":\"李春霞1\",\"cdept_num\":\"0803\",\"cdept_name\":\"成品仓\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"442000198502030948\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"13532068531\",\"cjobcode\":\"021\",\"vjobname\":\"成品仓普工\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1985-02-03\",\"timestamp\":\"518.6211\"},{\"row_count\":\"223\",\"RowNum\":\"20\",\"code\":\"GA259\",\"name\":\"唐敏洁\",\"cuser_id\":\"GA259\",\"cuser_name\":\"唐敏洁\",\"cdept_num\":\"100103\",\"cdept_name\":\"高柏诗商务部\",\"rsex\":\"2\",\"rpersontype\":\"101\",\"rpersontypename\":\"正式工\",\"rIDType\":\"0\",\"vIDNo\":\"431126199008249128\",\"rEmployState\":\"10\",\"cpsnmobilephone\":\"18028308727\",\"cjobcode\":\"040\",\"vjobname\":\"高柏诗商务文员\",\"bpsnperson\":\"1\",\"dBirthDate\":\"1990-08-24\",\"timestamp\":\"525.6177\"}]}";
            var json = System.Text.Json.JsonSerializer.Deserialize<PersonListResult>(s);
            Assert.IsNotNull(json);
        }


        [TestMethod]
        public void AutoCreate()
        {
            var className = "Job";

            var str = "using MicroFeel.Yonyou.Api.Model.Data;\r\n" +
                      "using System;\r\n" +
                      "using System.Collections.Generic;\r\n" +
                      "using System.Text;\r\n" +
                      "using System.Text.Json.Serialization;\r\n" +
                      "                        \r\n" +
                      "namespace MicroFeel.Yonyou.Api.Model.Result\r\n" +
                      "{                             \r\n" +
                      "public class " + className + "Result : " + className + ", IApiResult\r\n" +
                      "{\r\n" +
                      "[JsonPropertyName(\"errcode\")]\r\n" +
                      "public string Errcode { get; set; }\r\n" +
                      "[JsonPropertyName(\"errmsg\")]\r\n" +
                      "public string Errmsg { get; set; }\r\n" +
                      "}" +
                      "\r\n" +
                      "public class " + className + "ListResult : DbListResult<" + className + ">\r\n" +
                      "{\r\n" +
                      "[JsonPropertyName(\"" + className.ToLower() + "\")]\r\n" +
                      "public override List<" + className + "> List { get; set; }\r\n" +
                      "}\r\n" +
                      "}\r\n";


            //保存运行日志到程序运行文件夹下，并以当前日期命名
            string strpath = Directory.GetCurrentDirectory() + @"\result\" + className + "Result.cs";
            //获取strpath的文件夹名称，并判断不存在是创建文件夹
            if (!Directory.Exists(Path.GetDirectoryName(strpath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strpath));
            }
            //判断文件不存在时，创建该文件
            if (!File.Exists(strpath))
            {
                File.Create(strpath).Close();//创建完毕后，需关闭该IO通道，以使后续读写可继续进行
            }
            //使用数据流写入StreamWriter，true表示可持续写入，Encoding.Default前系统设置的默认字符集编码方式
            StreamWriter sw = new StreamWriter(strpath, true, Encoding.UTF8);
            sw.WriteLine(str);
            //销毁数据数据流通道
            sw.Dispose();
            //
            Console.WriteLine("写入成功");
        }
    }
}
