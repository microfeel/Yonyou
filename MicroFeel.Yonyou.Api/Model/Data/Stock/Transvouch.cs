using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Transvouch
    {
        ///<Summary>
        ///转入部门编码
        ///</Summary>
        [JsonPropertyName("idepcode")]
        public string Idepcode { get; set; }
        ///<Summary>
        ///转入部门名称
        ///</Summary>
        [JsonPropertyName("idepname")]
        public string Idepname { get; set; }
        ///<Summary>
        ///转出部门编码
        ///</Summary>
        [JsonPropertyName("odepcode")]
        public string Odepcode { get; set; }
        ///<Summary>
        ///转出部门名称
        ///</Summary>
        [JsonPropertyName("odepname")]
        public string Odepname { get; set; }
        ///<Summary>
        ///入库类别编码
        ///</Summary>
        [JsonPropertyName("irdcode")]
        public string Irdcode { get; set; }
        ///<Summary>
        ///入库类别名称
        ///</Summary>
        [JsonPropertyName("irdname")]
        public string Irdname { get; set; }
        ///<Summary>
        ///出库类别编码
        ///</Summary>
        [JsonPropertyName("ordcode")]
        public string Ordcode { get; set; }
        ///<Summary>
        ///出库类别名称
        ///</Summary>
        [JsonPropertyName("ordname")]
        public string Ordname { get; set; }
        ///<Summary>
        ///转入仓库编码
        ///</Summary>
        [JsonPropertyName("iwhcode")]
        public string Iwhcode { get; set; }
        ///<Summary>
        ///转入仓库名称
        ///</Summary>
        [JsonPropertyName("iwhname")]
        public string Iwhname { get; set; }
        ///<Summary>
        ///转出仓库编码
        ///</Summary>
        [JsonPropertyName("owhcode")]
        public string Owhcode { get; set; }
        ///<Summary>
        ///转出仓库名称
        ///</Summary>
        [JsonPropertyName("owhname")]
        public string Owhname { get; set; }
        ///<Summary>
        ///业务员编码
        ///</Summary>
        [JsonPropertyName("personcode")]
        public string Personcode { get; set; }
        ///<Summary>
        ///业务员名称
        ///</Summary>
        [JsonPropertyName("personname")]
        public string Personname { get; set; }
        ///<Summary>
        ///调拨单据号
        ///</Summary>
        [JsonPropertyName("tvcode")]
        public string Tvcode { get; set; }
        ///<Summary>
        ///单据日期
        ///</Summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        ///<Summary>
        ///备注
        ///</Summary>
        [JsonPropertyName("memory")]
        public string Memory { get; set; }
        ///<Summary>
        ///审核人
        ///</Summary>
        [JsonPropertyName("auditperson")]
        public string Auditperson { get; set; }
        ///<Summary>
        ///审核日期
        ///</Summary>
        [JsonPropertyName("auditdate")]
        public DateTime Auditdate { get; set; }
        ///<Summary>
        ///制单人
        ///</Summary>
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        ///<Summary>
        ///自定义字段1
        ///</Summary>
        [JsonPropertyName("define1")]
        public string Define1 { get; set; }
        ///<Summary>
        ///自定义字段2
        ///</Summary>
        [JsonPropertyName("define2")]
        public string Define2 { get; set; }
        ///<Summary>
        ///自定义字段3
        ///</Summary>
        [JsonPropertyName("define3")]
        public string Define3 { get; set; }
        ///<Summary>
        ///自定义字段4
        ///</Summary>
        [JsonPropertyName("define4")]
        public DateTime Define4 { get; set; }
        ///<Summary>
        ///自定义字段5
        ///</Summary>
        [JsonPropertyName("define5")]
        public float Define5 { get; set; }
        ///<Summary>
        ///自定义字段6
        ///</Summary>
        [JsonPropertyName("define6")]
        public DateTime Define6 { get; set; }
        ///<Summary>
        ///自定义字段7
        ///</Summary>
        [JsonPropertyName("define7")]
        public float Define7 { get; set; }
        ///<Summary>
        ///自定义字段8
        ///</Summary>
        [JsonPropertyName("define8")]
        public string Define8 { get; set; }
        ///<Summary>
        ///自定义字段9
        ///</Summary>
        [JsonPropertyName("define9")]
        public string Define9 { get; set; }
        ///<Summary>
        ///自定义字段10
        ///</Summary>
        [JsonPropertyName("define10")]
        public string Define10 { get; set; }
        ///<Summary>
        ///自定义字段11
        ///</Summary>
        [JsonPropertyName("define11")]
        public string Define11 { get; set; }
        ///<Summary>
        ///自定义字段12
        ///</Summary>
        [JsonPropertyName("define12")]
        public string Define12 { get; set; }
        ///<Summary>
        ///自定义字段13
        ///</Summary>
        [JsonPropertyName("define13")]
        public string Define13 { get; set; }
        ///<Summary>
        ///自定义字段14
        ///</Summary>
        [JsonPropertyName("define14")]
        public string Define14 { get; set; }
        ///<Summary>
        ///自定义字段15
        ///</Summary>
        [JsonPropertyName("define15")]
        public float Define15 { get; set; }
        ///<Summary>
        ///自定义字段16
        ///</Summary>
        [JsonPropertyName("define16")]
        public float Define16 { get; set; }
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
        ///订单类型
        ///</Summary>
        [JsonPropertyName("ordertype")]
        public string Ordertype { get; set; }
        ///<Summary>
        ///调拨申请单号
        ///</Summary>
        [JsonPropertyName("transappcode")]
        public string Transappcode { get; set; }
        ///<Summary>
        ///自由项10
        ///</Summary>
        [JsonPropertyName("csource")]
        public string Csource { get; set; }
        ///<Summary>
        ///条形码
        ///</Summary>
        [JsonPropertyName("entry")]
        public IList<TransvouchEntry> Transvouchentry { get; set; }


    }
    public class TransvouchEntry
    {

        ///<Summary>
        ///条形码
        ///</Summary>
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

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
        ///主计量单位名称
        ///</Summary>
        [JsonPropertyName("cmassunitname")]
        public string Cmassunitname { get; set; }

        ///<Summary>
        ///辅计量单位
        ///</Summary>
        [JsonPropertyName("assitantunit")]
        public string Assitantunit { get; set; }

        ///<Summary>
        ///辅计量单位名称
        ///</Summary>
        [JsonPropertyName("assitantunitname")]
        public string Assitantunitname { get; set; }

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
        ///价格
        ///</Summary>
        [JsonPropertyName("actualcost")]
        public float Actualcost { get; set; }

        ///<Summary>
        ///金额
        ///</Summary>
        [JsonPropertyName("actualprice")]
        public float Actualprice { get; set; }

        ///<Summary>
        ///调入货位
        ///</Summary>
        [JsonPropertyName("inposcode")]
        public float Inposcode { get; set; }

        ///<Summary>
        ///调出货位
        ///</Summary>
        [JsonPropertyName("outposcode")]
        public float Outposcode { get; set; }

        ///<Summary>
        ///表体自定义项22
        ///</Summary>
        [JsonPropertyName("define22")]
        public string Define22 { get; set; }

        ///<Summary>
        ///表体自定义项23
        ///</Summary>
        [JsonPropertyName("define23")]
        public string Define23 { get; set; }

        ///<Summary>
        ///表体自定义项24
        ///</Summary>
        [JsonPropertyName("define24")]
        public string Define24 { get; set; }

        ///<Summary>
        ///表体自定义项25
        ///</Summary>
        [JsonPropertyName("define25")]
        public string Define25 { get; set; }

        ///<Summary>
        ///表体自定义项26
        ///</Summary>
        [JsonPropertyName("define26")]
        public float Define26 { get; set; }

        ///<Summary>
        ///表体自定义项27
        ///</Summary>
        [JsonPropertyName("define27")]
        public float Define27 { get; set; }

        ///<Summary>
        ///表体自定义项28
        ///</Summary>
        [JsonPropertyName("define28")]
        public string Define28 { get; set; }

        ///<Summary>
        ///表体自定义项29
        ///</Summary>
        [JsonPropertyName("define29")]
        public string Define29 { get; set; }

        ///<Summary>
        ///表体自定义项30
        ///</Summary>
        [JsonPropertyName("define30")]
        public string Define30 { get; set; }

        ///<Summary>
        ///表体自定义项31
        ///</Summary>
        [JsonPropertyName("define31")]
        public string Define31 { get; set; }

        ///<Summary>
        ///表体自定义项32
        ///</Summary>
        [JsonPropertyName("define32")]
        public string Define32 { get; set; }

        ///<Summary>
        ///表体自定义项33
        ///</Summary>
        [JsonPropertyName("define33")]
        public string Define33 { get; set; }

        ///<Summary>
        ///表体自定义项34
        ///</Summary>
        [JsonPropertyName("define34")]
        public float Define34 { get; set; }

        ///<Summary>
        ///表体自定义项35
        ///</Summary>
        [JsonPropertyName("define35")]
        public float Define35 { get; set; }

        ///<Summary>
        ///表体自定义项36
        ///</Summary>
        [JsonPropertyName("define36")]
        public DateTime Define36 { get; set; }

        ///<Summary>
        ///表体自定义项37
        ///</Summary>
        [JsonPropertyName("define37")]
        public DateTime Define37 { get; set; }

        ///<Summary>
        ///行号
        ///</Summary>
        [JsonPropertyName("irowno")]
        public float Irowno { get; set; }

        ///<Summary>
        ///存货名称
        ///</Summary>
        [JsonPropertyName("inventoryname")]
        public string Inventoryname { get; set; }

    }
}