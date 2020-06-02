using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Productin
    {
        ///<Summary>
        ///单据编号
        ///</Summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        ///<Summary>
        ///制单日期
        ///</Summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        ///<Summary>
        ///制单人名称
        ///</Summary>
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        ///<Summary>
        ///仓库编码
        ///</Summary>
        [JsonPropertyName("warehousecode")]
        public string Warehousecode { get; set; }
        ///<Summary>
        ///备注
        ///</Summary>
        [JsonPropertyName("memory")]
        public string Memory { get; set; }
        ///<Summary>
        ///收发类型编码
        ///</Summary>
        [JsonPropertyName("receivecode")]
        public string Receivecode { get; set; }
        ///<Summary>
        ///部门编码
        ///</Summary>
        [JsonPropertyName("departmentcode")]
        public string Departmentcode { get; set; }
        ///<Summary>
        ///单据头自定义项1
        ///</Summary>
        [JsonPropertyName("define1")]
        public string Define1 { get; set; }
        ///<Summary>
        ///单据头自定义项2
        ///</Summary>
        [JsonPropertyName("define2")]
        public string Define2 { get; set; }
        ///<Summary>
        ///单据头自定义项3
        ///</Summary>
        [JsonPropertyName("define3")]
        public string Define3 { get; set; }
        ///<Summary>
        ///单据头自定义项4
        ///</Summary>
        [JsonPropertyName("define4")]
        public DateTime Define4 { get; set; }
        ///<Summary>
        ///单据头自定义项5
        ///</Summary>
        [JsonPropertyName("define5")]
        public float Define5 { get; set; }
        ///<Summary>
        ///单据头自定义项6
        ///</Summary>
        [JsonPropertyName("define6")]
        public DateTime Define6 { get; set; }
        ///<Summary>
        ///单据头自定义项7
        ///</Summary>
        [JsonPropertyName("define7")]
        public float Define7 { get; set; }
        ///<Summary>
        ///单据头自定义项8
        ///</Summary>
        [JsonPropertyName("define8")]
        public string Define8 { get; set; }
        ///<Summary>
        ///单据头自定义项9
        ///</Summary>
        [JsonPropertyName("define9")]
        public string Define9 { get; set; }
        ///<Summary>
        ///单据头自定义项10
        ///</Summary>
        [JsonPropertyName("define10")]
        public string Define10 { get; set; }
        ///<Summary>
        ///单据头自定义项11
        ///</Summary>
        [JsonPropertyName("define11")]
        public string Define11 { get; set; }
        ///<Summary>
        ///单据头自定义项12
        ///</Summary>
        [JsonPropertyName("define12")]
        public string Define12 { get; set; }
        ///<Summary>
        ///单据头自定义项13
        ///</Summary>
        [JsonPropertyName("define13")]
        public string Define13 { get; set; }
        ///<Summary>
        ///单据头自定义项14
        ///</Summary>
        [JsonPropertyName("define14")]
        public string Define14 { get; set; }
        ///<Summary>
        ///单据头自定义项15
        ///</Summary>
        [JsonPropertyName("define15")]
        public float Define15 { get; set; }
        ///<Summary>
        ///单据头自定义项16
        ///</Summary>
        [JsonPropertyName("define16")]
        public float Define16 { get; set; }
        ///<Summary>
        ///存货编码
        ///</Summary>
        [JsonPropertyName("entry")]
        public IList<ProductinEntry> Productinentry { get; set; }
    }
    public class ProductinEntry
    {

        ///<Summary>
        ///存货编码
        ///</Summary>
        [JsonPropertyName("inventorycode")]
        public string Inventorycode { get; set; }

        ///<Summary>
        ///数量
        ///</Summary>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        ///<Summary>
        ///辅记量单位编码
        ///</Summary>
        [JsonPropertyName("assitantunit")]
        public string Assitantunit { get; set; }

        ///<Summary>
        ///换算率
        ///</Summary>
        [JsonPropertyName("irate")]
        public float Irate { get; set; }

        ///<Summary>
        ///件数
        ///</Summary>
        [JsonPropertyName("number")]
        public float Number { get; set; }

        ///<Summary>
        ///单价
        ///</Summary>
        [JsonPropertyName("price")]
        public float Price { get; set; }

        ///<Summary>
        ///金额
        ///</Summary>
        [JsonPropertyName("cost")]
        public float Cost { get; set; }

        ///<Summary>
        ///批号
        ///</Summary>
        [JsonPropertyName("serial")]
        public string Serial { get; set; }

        ///<Summary>
        ///生产日期
        ///</Summary>
        [JsonPropertyName("makedate")]
        public DateTime Makedate { get; set; }

        ///<Summary>
        ///失效日期
        ///</Summary>
        [JsonPropertyName("validdate")]
        public DateTime Validdate { get; set; }

        ///<Summary>
        ///自由项1
        ///</Summary>
        [JsonPropertyName("free1")]
        public string Free1 { get; set; }

        ///<Summary>
        ///自由项2
        ///</Summary>
        [JsonPropertyName("free2")]
        public string Free2 { get; set; }

        ///<Summary>
        ///自由项3
        ///</Summary>
        [JsonPropertyName("free3")]
        public string Free3 { get; set; }

        ///<Summary>
        ///自由项4
        ///</Summary>
        [JsonPropertyName("free4")]
        public string Free4 { get; set; }

        ///<Summary>
        ///自由项5
        ///</Summary>
        [JsonPropertyName("free5")]
        public string Free5 { get; set; }

        ///<Summary>
        ///自由项6
        ///</Summary>
        [JsonPropertyName("free6")]
        public string Free6 { get; set; }

        ///<Summary>
        ///自由项7
        ///</Summary>
        [JsonPropertyName("free7")]
        public string Free7 { get; set; }

        ///<Summary>
        ///自由项8
        ///</Summary>
        [JsonPropertyName("free8")]
        public string Free8 { get; set; }

        ///<Summary>
        ///自由项9
        ///</Summary>
        [JsonPropertyName("free9")]
        public string Free9 { get; set; }

        ///<Summary>
        ///自由项10
        ///</Summary>
        [JsonPropertyName("free10")]
        public string Free10 { get; set; }

        ///<Summary>
        ///单据体自定义项1
        ///</Summary>
        [JsonPropertyName("define22")]
        public string Define22 { get; set; }

        ///<Summary>
        ///单据体自定义项2
        ///</Summary>
        [JsonPropertyName("define23")]
        public string Define23 { get; set; }

        ///<Summary>
        ///单据体自定义项3
        ///</Summary>
        [JsonPropertyName("define24")]
        public string Define24 { get; set; }

        ///<Summary>
        ///单据体自定义项4
        ///</Summary>
        [JsonPropertyName("define25")]
        public string Define25 { get; set; }

        ///<Summary>
        ///单据体自定义项5
        ///</Summary>
        [JsonPropertyName("define26")]
        public float Define26 { get; set; }

        ///<Summary>
        ///单据体自定义项6
        ///</Summary>
        [JsonPropertyName("define27")]
        public float Define27 { get; set; }

        ///<Summary>
        ///单据体自定义项7
        ///</Summary>
        [JsonPropertyName("define28")]
        public string Define28 { get; set; }

        ///<Summary>
        ///单据体自定义项8
        ///</Summary>
        [JsonPropertyName("define29")]
        public string Define29 { get; set; }

        ///<Summary>
        ///单据体自定义项9
        ///</Summary>
        [JsonPropertyName("define30")]
        public string Define30 { get; set; }

        ///<Summary>
        ///单据体自定义项10
        ///</Summary>
        [JsonPropertyName("define31")]
        public string Define31 { get; set; }

        ///<Summary>
        ///单据体自定义项11
        ///</Summary>
        [JsonPropertyName("define32")]
        public string Define32 { get; set; }

        ///<Summary>
        ///单据体自定义项12
        ///</Summary>
        [JsonPropertyName("define33")]
        public string Define33 { get; set; }

        ///<Summary>
        ///单据体自定义项13
        ///</Summary>
        [JsonPropertyName("define34")]
        public float Define34 { get; set; }

        ///<Summary>
        ///单据体自定义项14
        ///</Summary>
        [JsonPropertyName("define35")]
        public float Define35 { get; set; }

        ///<Summary>
        ///单据体自定义项15
        ///</Summary>
        [JsonPropertyName("define36")]
        public DateTime Define36 { get; set; }

        ///<Summary>
        ///单据体自定义项16
        ///</Summary>
        [JsonPropertyName("define37")]
        public DateTime Define37 { get; set; }

        ///<Summary>
        ///行号
        ///</Summary>
        [JsonPropertyName("rowno")]
        public float Rowno { get; set; }

    }
}