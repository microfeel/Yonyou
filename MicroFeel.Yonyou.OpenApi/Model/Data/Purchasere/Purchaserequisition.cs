using System;using System.Collections.Generic;using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Purchaserequisition
    {
        ///<Summary>
        ///单据编号
        ///</Summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        ///<Summary>
        ///单据日期(默认当天)
        ///</Summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        ///<Summary>
        ///部门编号
        ///</Summary>
        [JsonPropertyName("departmentcode")]
        public string Departmentcode { get; set; }
        ///<Summary>
        ///职员编号
        ///</Summary>
        [JsonPropertyName("personcode")]
        public string Personcode { get; set; }
        ///<Summary>
        ///采购类型编码
        ///</Summary>
        [JsonPropertyName("purchasetypecode")]
        public string Purchasetypecode { get; set; }
        ///<Summary>
        ///业务类型
        ///</Summary>
        [JsonPropertyName("businesstype")]
        public string Businesstype { get; set; }
        ///<Summary>
        ///制单
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
        ///备注
        ///</Summary>
        [JsonPropertyName("memory")]
        public string Memory { get; set; }
        ///<Summary>
        ///供应商编号
        ///</Summary>
        [JsonPropertyName("entry")]
        public IList<PurchaserequisitionEntry> Purchaserequisitionentry { get; set; }
    }

    public class PurchaserequisitionEntry
    {

        ///<Summary>
        ///供应商编号
        ///</Summary>
        [JsonPropertyName("vendorcode")]
        public string Vendorcode { get; set; }

        ///<Summary>
        ///存货编号
        ///</Summary>
        [JsonPropertyName("inventorycode")]
        public string Inventorycode { get; set; }

        ///<Summary>
        ///数量
        ///</Summary>
        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        ///<Summary>
        ///本币单价
        ///</Summary>
        [JsonPropertyName("price")]
        public string Price { get; set; }

        ///<Summary>
        ///税率（默认17）
        ///</Summary>
        [JsonPropertyName("taxrate")]
        public string Taxrate { get; set; }

        ///<Summary>
        ///本币含税单价
        ///</Summary>
        [JsonPropertyName("taxprice")]
        public string Taxprice { get; set; }

        ///<Summary>
        ///本币金额
        ///</Summary>
        [JsonPropertyName("money")]
        public string Money { get; set; }

        ///<Summary>
        ///本币税额
        ///</Summary>
        [JsonPropertyName("tax")]
        public string Tax { get; set; }

        ///<Summary>
        ///本币价税合计
        ///</Summary>
        [JsonPropertyName("sum")]
        public string Sum { get; set; }

        ///<Summary>
        ///需求日期（默认当天）
        ///</Summary>
        [JsonPropertyName("requiredate")]
        public DateTime Requiredate { get; set; }

        ///<Summary>
        ///建议订货日期（默认当天）
        ///</Summary>
        [JsonPropertyName("arrivedate")]
        public DateTime Arrivedate { get; set; }

        ///<Summary>
        ///项目大类编码
        ///</Summary>
        [JsonPropertyName("item_class")]
        public string ItemClass { get; set; }

        ///<Summary>
        ///项目编码
        ///</Summary>
        [JsonPropertyName("item_code")]
        public string ItemCode { get; set; }

        ///<Summary>
        ///项目名称
        ///</Summary>
        [JsonPropertyName("item_name")]
        public string ItemName { get; set; }

        ///<Summary>
        ///单价标准
        ///</Summary>
        [JsonPropertyName("btaxcost")]
        public string Btaxcost { get; set; }

        ///<Summary>
        ///件数
        ///</Summary>
        [JsonPropertyName("num")]
        public string Num { get; set; }

        ///<Summary>
        ///单位编码
        ///</Summary>
        [JsonPropertyName("unitid")]
        public string Unitid { get; set; }

        ///<Summary>
        ///执行部门
        ///</Summary>
        [JsonPropertyName("deptcodeexec")]
        public string Deptcodeexec { get; set; }

        ///<Summary>
        ///执行采购员
        ///</Summary>
        [JsonPropertyName("personcodeexec")]
        public string Personcodeexec { get; set; }

        ///<Summary>
        ///币种（默认:人民币）
        ///</Summary>
        [JsonPropertyName("currency_name")]
        public string CurrencyName { get; set; }

        ///<Summary>
        ///汇率（默认:1）
        ///</Summary>
        [JsonPropertyName("currency_rate")]
        public string CurrencyRate { get; set; }

        ///<Summary>
        ///原币单价
        ///</Summary>
        [JsonPropertyName("originalprice")]
        public string Originalprice { get; set; }

        ///<Summary>
        ///含税单价
        ///</Summary>
        [JsonPropertyName("originaltaxedprice")]
        public string Originaltaxedprice { get; set; }

        ///<Summary>
        ///原币金额
        ///</Summary>
        [JsonPropertyName("originalmoney")]
        public string Originalmoney { get; set; }

        ///<Summary>
        ///原币税额
        ///</Summary>
        [JsonPropertyName("originaltax")]
        public string Originaltax { get; set; }

        ///<Summary>
        ///原币价税合计
        ///</Summary>
        [JsonPropertyName("originalsum")]
        public string Originalsum { get; set; }

        ///<Summary>
        ///行号
        ///</Summary>
        [JsonPropertyName("ivouchrowno")]
        public string Ivouchrowno { get; set; }

        ///<Summary>
        ///表体自定义项1
        ///</Summary>
        [JsonPropertyName("define22")]
        public string Define22 { get; set; }

        ///<Summary>
        ///表体自定义项2
        ///</Summary>
        [JsonPropertyName("define23")]
        public string Define23 { get; set; }

        ///<Summary>
        ///表体自定义项3
        ///</Summary>
        [JsonPropertyName("define24")]
        public string Define24 { get; set; }

        ///<Summary>
        ///表体自定义项4
        ///</Summary>
        [JsonPropertyName("define25")]
        public string Define25 { get; set; }

        ///<Summary>
        ///表体自定义项5
        ///</Summary>
        [JsonPropertyName("define26")]
        public string Define26 { get; set; }

        ///<Summary>
        ///表体自定义项6
        ///</Summary>
        [JsonPropertyName("define27")]
        public string Define27 { get; set; }

        ///<Summary>
        ///表体自定义项7
        ///</Summary>
        [JsonPropertyName("define28")]
        public string Define28 { get; set; }

        ///<Summary>
        ///表体自定义项8
        ///</Summary>
        [JsonPropertyName("define29")]
        public string Define29 { get; set; }

        ///<Summary>
        ///表体自定义项9
        ///</Summary>
        [JsonPropertyName("define30")]
        public string Define30 { get; set; }

        ///<Summary>
        ///表体自定义项10
        ///</Summary>
        [JsonPropertyName("define31")]
        public string Define31 { get; set; }

        ///<Summary>
        ///表体自定义项11
        ///</Summary>
        [JsonPropertyName("define32")]
        public string Define32 { get; set; }

        ///<Summary>
        ///表体自定义项12
        ///</Summary>
        [JsonPropertyName("define33")]
        public string Define33 { get; set; }

        ///<Summary>
        ///表体自定义项13
        ///</Summary>
        [JsonPropertyName("define34")]
        public float Define34 { get; set; }

        ///<Summary>
        ///表体自定义项14
        ///</Summary>
        [JsonPropertyName("define35")]
        public string Define35 { get; set; }

        ///<Summary>
        ///表体自定义项15
        ///</Summary>
        [JsonPropertyName("define36")]
        public DateTime Define36 { get; set; }

        ///<Summary>
        ///表体自定义项16
        ///</Summary>
        [JsonPropertyName("define37")]
        public DateTime Define37 { get; set; }

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

    }

}