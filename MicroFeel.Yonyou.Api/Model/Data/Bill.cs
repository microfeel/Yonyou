using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Post
{
    public class Bill
    {
        ///<summary>
        ///		否	单据编号
        ///</summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        ///<summary>
        ///		否	制单日期
        ///</summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        ///<summary>
        ///		否	制单人名称
        ///</summary>
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        ///<summary>
        ///		是	仓库编码
        ///</summary>
        [JsonPropertyName("warehousecode")]
        public string Warehousecode { get; set; }
        ///<summary>
        ///		否	备注
        ///</summary>
        [JsonPropertyName("memory")]
        public string Memory { get; set; }
        ///<summary>
        ///		是	收发类型编码
        ///</summary>
        [JsonPropertyName("receivecode")]
        public string Receivecode { get; set; }
        ///<summary>
        ///		是	部门编码
        ///</summary>
        [JsonPropertyName("departmentcode")]
        public string Departmentcode { get; set; }
        ///<summary>
        ///		否	单据头自定义项1
        ///</summary>
        [JsonPropertyName("define1")]
        public string Define1 { get; set; }
        ///<summary>
        ///		否	单据头自定义项2
        ///</summary>
        [JsonPropertyName("define2")]
        public string Define2 { get; set; }
        ///<summary>
        ///		否	单据头自定义项3
        ///</summary>
        [JsonPropertyName("define3")]
        public string Define3 { get; set; }
        ///<summary>
        ///		否	单据头自定义项4
        ///</summary>
        [JsonPropertyName("define4")]
        public DateTime Define4 { get; set; }
        ///<summary>
        ///		否	单据头自定义项5
        ///</summary>
        [JsonPropertyName("define5")]
        public string Define5 { get; set; }
        ///<summary>
        ///		否	单据头自定义项6
        ///</summary>
        [JsonPropertyName("define6")]
        public DateTime Define6 { get; set; }
        ///<summary>
        ///		否	单据头自定义项7
        ///</summary>
        [JsonPropertyName("define7")]
        public string Define7 { get; set; }
        ///<summary>
        ///		否	单据头自定义项8
        ///</summary>
        [JsonPropertyName("define8")]
        public string Define8 { get; set; }
        ///<summary>
        ///		否	单据头自定义项9
        ///</summary>
        [JsonPropertyName("define9")]
        public string Define9 { get; set; }
        ///<summary>
        ///		否	单据头自定义项10
        ///</summary>
        [JsonPropertyName("define10")]
        public string Define10 { get; set; }
        ///<summary>
        ///		否	单据头自定义项11
        ///</summary>
        [JsonPropertyName("define11")]
        public string Define11 { get; set; }
        ///<summary>
        ///		否	单据头自定义项12
        ///</summary>
        [JsonPropertyName("define12")]
        public string Define12 { get; set; }
        ///<summary>
        ///		否	单据头自定义项13
        ///</summary>
        [JsonPropertyName("define13")]
        public string Define13 { get; set; }
        ///<summary>
        ///		否	单据头自定义项14
        ///</summary>
        [JsonPropertyName("define14")]
        public string Define14 { get; set; }
        ///<summary>
        ///		否	单据头自定义项15
        ///</summary>
        [JsonPropertyName("define15")]
        public string Define15 { get; set; }
        ///<summary>
        ///		否	单据头自定义项16
        ///</summary>
        [JsonPropertyName("define16")]
        public string Define16 { get; set; }

        [JsonPropertyName("entry")]
        public BillEntry Entry { get; set; }
    }

    public class BillEntry
    {
        ///<summary>
        ///	是	存货编码
        ///</summary>
        [JsonPropertyName("inventorycode")]
        public string Inventorycode { get; set; }
        ///<summary>
        ///	否	数量
        ///</summary>
        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }
        ///<summary>
        ///	否	辅记量单位编码
        ///</summary>
        [JsonPropertyName("assitantunit")]
        public string Assitantunit { get; set; }
        ///<summary>
        ///	否	换算率
        ///</summary>
        [JsonPropertyName("irate")]
        public string Irate { get; set; }
        ///<summary>
        ///	否	件数
        ///</summary>
        [JsonPropertyName("string")]
        public string Number { get; set; }
        ///<summary>
        ///	否	单价
        ///</summary>
        [JsonPropertyName("price")]
        public string Price { get; set; }
        ///<summary>
        ///	是	金额
        ///</summary>
        [JsonPropertyName("cost")]
        public string Cost { get; set; }
        ///<summary>
        ///	否	批号
        ///</summary>
        [JsonPropertyName("serial")]
        public string Serial { get; set; }
        ///<summary>
        ///	否	生产日期
        ///</summary>
        [JsonPropertyName("makedate")]
        public DateTime Makedate { get; set; }
        ///<summary>
        ///	否	失效日期
        ///</summary>
        [JsonPropertyName("validdate")]
        public DateTime Validdate { get; set; }
        ///<summary>
        ///	否	自由项1
        ///</summary>
        [JsonPropertyName("free1")]
        public string Free1 { get; set; }
        ///<summary>
        ///	否	自由项2
        ///</summary>
        [JsonPropertyName("free2")]
        public string Free2 { get; set; }
        ///<summary>
        ///	否	自由项3
        ///</summary>
        [JsonPropertyName("free3")]
        public string Free3 { get; set; }
        ///<summary>
        ///	否	自由项4
        ///</summary>
        [JsonPropertyName("free4")]
        public string Free4 { get; set; }
        ///<summary>
        ///	否	自由项5
        ///</summary>
        [JsonPropertyName("free5")]
        public string Free5 { get; set; }
        ///<summary>
        ///	否	自由项6
        ///</summary>
        [JsonPropertyName("free6")]
        public string Free6 { get; set; }
        ///<summary>
        ///	否	自由项7
        ///</summary>
        [JsonPropertyName("free7")]
        public string Free7 { get; set; }
        ///<summary>
        ///	否	自由项8
        ///</summary>
        [JsonPropertyName("free8")]
        public string Free8 { get; set; }
        ///<summary>
        ///	否	自由项9
        ///</summary>
        [JsonPropertyName("free9")]
        public string Free9 { get; set; }
        ///<summary>
        ///	否	自由项10
        ///</summary>
        [JsonPropertyName("free10")]
        public string Free10 { get; set; }
        ///<summary>
        ///	否	单据体自定义项1
        ///</summary>
        [JsonPropertyName("define22")]
        public string Define22 { get; set; }
        ///<summary>
        ///	否	单据体自定义项2
        ///</summary>
        [JsonPropertyName("define23")]
        public string Define23 { get; set; }
        ///<summary>
        ///	否	单据体自定义项3
        ///</summary>
        [JsonPropertyName("define24")]
        public string Define24 { get; set; }
        ///<summary>
        ///	否	单据体自定义项4
        ///</summary>
        [JsonPropertyName("define25")]
        public string Define25 { get; set; }
        ///<summary>
        ///	否	单据体自定义项5
        ///</summary>
        [JsonPropertyName("define26")]
        public string Define26 { get; set; }
        ///<summary>
        ///	否	单据体自定义项6
        ///</summary>
        [JsonPropertyName("define27")]
        public string Define27 { get; set; }
        ///<summary>
        ///	否	单据体自定义项7
        ///</summary>
        [JsonPropertyName("define28")]
        public string Define28 { get; set; }
        ///<summary>
        ///	否	单据体自定义项8
        ///</summary>
        [JsonPropertyName("define29")]
        public string Define29 { get; set; }
        ///<summary>
        ///	否	单据体自定义项9
        ///</summary>
        [JsonPropertyName("define30")]
        public string Define30 { get; set; }
        ///<summary>
        ///	否	单据体自定义项10
        ///</summary>
        [JsonPropertyName("define31")]
        public string Define31 { get; set; }
        ///<summary>
        ///	否	单据体自定义项11
        ///</summary>
        [JsonPropertyName("define32")]
        public string Define32 { get; set; }
        ///<summary>
        ///	否	单据体自定义项12
        ///</summary>
        [JsonPropertyName("define33")]
        public string Define33 { get; set; }
        ///<summary>
        ///	否	单据体自定义项13
        ///</summary>
        [JsonPropertyName("define34")]
        public string Define34 { get; set; }
        ///<summary>
        ///	否	单据体自定义项14
        ///</summary>
        [JsonPropertyName("define35")]
        public string Define35 { get; set; }
        ///<summary>
        ///	否	单据体自定义项15
        ///</summary>
        [JsonPropertyName("define36")]
        public DateTime Define36 { get; set; }
        ///<summary>
        ///	否	单据体自定义项16
        ///</summary>
        [JsonPropertyName("define37")]
        public DateTime Define37 { get; set; }
        ///<summary>
        ///	否	行号
        ///</summary>
        [JsonPropertyName("rowno")]
        public string Rowno { get; set; }
    }
}
