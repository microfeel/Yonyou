using System;using System.Collections.Generic;using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Purchaseinvoice
    {
        ///<Summary>
        ///单据来源
        ///</Summary>
        [JsonPropertyName("csource")]
        public string Csource { get; set; }
        ///<Summary>
        ///发票类型
        ///</Summary>
        [JsonPropertyName("invoicetype")]
        public string Invoicetype { get; set; }
        ///<Summary>
        ///发票号
        ///</Summary>
        [JsonPropertyName("invoicecode")]
        public string Invoicecode { get; set; }
        ///<Summary>
        ///采购类型编号
        ///</Summary>
        [JsonPropertyName("purchasecode")]
        public string Purchasecode { get; set; }
        ///<Summary>
        ///开票日期
        ///</Summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        ///<Summary>
        ///供应商编号
        ///</Summary>
        [JsonPropertyName("vendorcode")]
        public string Vendorcode { get; set; }
        ///<Summary>
        ///代垫单位编号
        ///</Summary>
        [JsonPropertyName("delegatecode")]
        public string Delegatecode { get; set; }
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
        ///结算日期
        ///</Summary>
        [JsonPropertyName("dsdate")]
        public DateTime Dsdate { get; set; }
        ///<Summary>
        ///扣税类别
        ///</Summary>
        [JsonPropertyName("idiscounttaxtype")]
        public float Idiscounttaxtype { get; set; }
        ///<Summary>
        ///付款条件编码
        ///</Summary>
        [JsonPropertyName("payconditioncode")]
        public string Payconditioncode { get; set; }
        ///<Summary>
        ///外币名称
        ///</Summary>
        [JsonPropertyName("foreigncurrency")]
        public string Foreigncurrency { get; set; }
        ///<Summary>
        ///汇率
        ///</Summary>
        [JsonPropertyName("foreigncurrencyrate")]
        public string Foreigncurrencyrate { get; set; }
        ///<Summary>
        ///税率
        ///</Summary>
        [JsonPropertyName("taxrate")]
        public float Taxrate { get; set; }
        ///<Summary>
        ///备注
        ///</Summary>
        [JsonPropertyName("memory")]
        public string Memory { get; set; }
        ///<Summary>
        ///业务类型
        ///</Summary>
        [JsonPropertyName("businesstype")]
        public string Businesstype { get; set; }
        ///<Summary>
        ///制单人
        ///</Summary>
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        ///<Summary>
        ///负发票标志
        ///</Summary>
        [JsonPropertyName("isnegative")]
        public bool Isnegative { get; set; }
        ///<Summary>
        ///收付款协议编码
        ///</Summary>
        [JsonPropertyName("protocolcode")]
        public string Protocolcode { get; set; }
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
        public string Define4 { get; set; }
        ///<Summary>
        ///自定义字段5
        ///</Summary>
        [JsonPropertyName("define5")]
        public string Define5 { get; set; }
        ///<Summary>
        ///自定义字段6
        ///</Summary>
        [JsonPropertyName("define6")]
        public string Define6 { get; set; }
        ///<Summary>
        ///自定义字段7
        ///</Summary>
        [JsonPropertyName("define7")]
        public string Define7 { get; set; }
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
        public string Define15 { get; set; }
        ///<Summary>
        ///自定义字段16
        ///</Summary>
        [JsonPropertyName("define16")]
        public string Define16 { get; set; }
        ///<Summary>
        ///存货编码
        ///</Summary>
        [JsonPropertyName("entry")]
        public IList<PurchaseinvoiceEntry> Purchaseinvoiceentry { get; set; }
    }

    public class PurchaseinvoiceEntry
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
        ///辅计量单位
        ///</Summary>
        [JsonPropertyName("assistantunit")]
        public string Assistantunit { get; set; }

        ///<Summary>
        ///件数
        ///</Summary>
        [JsonPropertyName("number")]
        public float Number { get; set; }

        ///<Summary>
        ///原币单价
        ///</Summary>
        [JsonPropertyName("originalprice")]
        public float Originalprice { get; set; }

        ///<Summary>
        ///原币含税单价
        ///</Summary>
        [JsonPropertyName("oritaxcost")]
        public float Oritaxcost { get; set; }

        ///<Summary>
        ///原币金额
        ///</Summary>
        [JsonPropertyName("originalmoney")]
        public float Originalmoney { get; set; }

        ///<Summary>
        ///原币税额
        ///</Summary>
        [JsonPropertyName("originaltax")]
        public float Originaltax { get; set; }

        ///<Summary>
        ///原币价税合计
        ///</Summary>
        [JsonPropertyName("originalsum")]
        public float Originalsum { get; set; }

        ///<Summary>
        ///本币单价
        ///</Summary>
        [JsonPropertyName("price")]
        public float Price { get; set; }

        ///<Summary>
        ///本币金额
        ///</Summary>
        [JsonPropertyName("money")]
        public float Money { get; set; }

        ///<Summary>
        ///本币税额
        ///</Summary>
        [JsonPropertyName("tax")]
        public float Tax { get; set; }

        ///<Summary>
        ///本币价税合计
        ///</Summary>
        [JsonPropertyName("sum")]
        public float Sum { get; set; }


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
        public string Define34 { get; set; }

        ///<Summary>
        ///表体自定义项14
        ///</Summary>
        [JsonPropertyName("define35")]
        public string Define35 { get; set; }

        ///<Summary>
        ///表体自定义项15
        ///</Summary>
        [JsonPropertyName("define36")]
        public string Define36 { get; set; }

        ///<Summary>
        ///表体自定义项16
        ///</Summary>
        [JsonPropertyName("define37")]
        public string Define37 { get; set; }

        ///<Summary>
        ///项目大类编码
        ///</Summary>
        [JsonPropertyName("itemclasscode")]
        public string Itemclasscode { get; set; }

        ///<Summary>
        ///项目编码
        ///</Summary>
        [JsonPropertyName("itemcode")]
        public string Itemcode { get; set; }

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
        ///是否为费用
        ///</Summary>
        [JsonPropertyName("isfee")]
        public bool Isfee { get; set; }

        ///<Summary>
        ///行号
        ///</Summary>
        [JsonPropertyName("ivouchrowno")]
        public float Ivouchrowno { get; set; }

    }

}