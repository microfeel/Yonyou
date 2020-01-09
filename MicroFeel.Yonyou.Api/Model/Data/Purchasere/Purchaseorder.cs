using System;using System.Collections.Generic;using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Purchaseorder
    {
        ///<Summary>
        ///订单编号
        ///</Summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        ///<Summary>
        ///订单日期，默认取系统日期
        ///</Summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        ///<Summary>
        ///采购业务类型，默认普通采购
        ///</Summary>
        [JsonPropertyName("operation_type_code")]
        public string OperationTypeCode { get; set; }
        ///<Summary>
        ///订单状态
        ///</Summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
        ///<Summary>
        ///采购类型编码
        ///</Summary>
        [JsonPropertyName("purchase_type_code")]
        public string PurchaseTypeCode { get; set; }
        ///<Summary>
        ///采购类型
        ///</Summary>
        [JsonPropertyName("purchase_type_name")]
        public string PurchaseTypeName { get; set; }
        ///<Summary>
        ///供应商编码
        ///</Summary>
        [JsonPropertyName("vendorcode")]
        public string Vendorcode { get; set; }
        ///<Summary>
        ///供应商名称
        ///</Summary>
        [JsonPropertyName("vendorname")]
        public string Vendorname { get; set; }
        ///<Summary>
        ///供应商简称
        ///</Summary>
        [JsonPropertyName("vendorabbname")]
        public string Vendorabbname { get; set; }
        ///<Summary>
        ///部门编码
        ///</Summary>
        [JsonPropertyName("deptcode")]
        public string Deptcode { get; set; }
        ///<Summary>
        ///部门名称
        ///</Summary>
        [JsonPropertyName("deptname")]
        public string Deptname { get; set; }
        ///<Summary>
        ///业务员编码
        ///</Summary>
        [JsonPropertyName("personcode")]
        public string Personcode { get; set; }
        ///<Summary>
        ///业务员
        ///</Summary>
        [JsonPropertyName("personname")]
        public string Personname { get; set; }
        ///<Summary>
        ///制单人
        ///</Summary>
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        ///<Summary>
        ///审核人
        ///</Summary>
        [JsonPropertyName("verifier")]
        public string Verifier { get; set; }
        ///<Summary>
        ///关闭人
        ///</Summary>
        [JsonPropertyName("closer")]
        public string Closer { get; set; }
        ///<Summary>
        ///外币名称
        ///</Summary>
        [JsonPropertyName("currency_name")]
        public string CurrencyName { get; set; }
        ///<Summary>
        ///汇率
        ///</Summary>
        [JsonPropertyName("currency_rate")]
        public float CurrencyRate { get; set; }
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
        ///备注
        ///</Summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }
        ///<Summary>
        ///存货编码
        ///</Summary>
        [JsonPropertyName("entry")]
        public IList<PurchaseorderEntry> Purchaseorderentry { get; set; }
    }

    public class PurchaseorderEntry
    {

        ///<Summary>
        ///存货编码
        ///</Summary>
        [JsonPropertyName("inventorycode")]
        public string Inventorycode { get; set; }

        ///<Summary>
        ///存货名称
        ///</Summary>
        [JsonPropertyName("inventoryname")]
        public string Inventoryname { get; set; }

        ///<Summary>
        ///规格型号
        ///</Summary>
        [JsonPropertyName("inventorystd")]
        public string Inventorystd { get; set; }

        ///<Summary>
        ///采购单位编码
        ///</Summary>
        [JsonPropertyName("unitcode")]
        public string Unitcode { get; set; }

        ///<Summary>
        ///采购单位
        ///</Summary>
        [JsonPropertyName("unitname")]
        public string Unitname { get; set; }

        ///<Summary>
        ///数量
        ///</Summary>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        ///<Summary>
        ///计划到货日期
        ///</Summary>
        [JsonPropertyName("arrivedate")]
        public DateTime Arrivedate { get; set; }

        ///<Summary>
        ///原币单价
        ///</Summary>
        [JsonPropertyName("price")]
        public float Price { get; set; }

        ///<Summary>
        ///报价
        ///</Summary>
        [JsonPropertyName("quotedprice")]
        public float Quotedprice { get; set; }

        ///<Summary>
        ///含税单价
        ///</Summary>
        [JsonPropertyName("taxprice")]
        public float Taxprice { get; set; }

        ///<Summary>
        ///原币金额
        ///</Summary>
        [JsonPropertyName("money")]
        public float Money { get; set; }

        ///<Summary>
        ///原币税额
        ///</Summary>
        [JsonPropertyName("tax")]
        public float Tax { get; set; }

        ///<Summary>
        ///原币价税合计
        ///</Summary>
        [JsonPropertyName("sum")]
        public float Sum { get; set; }

        ///<Summary>
        ///折扣额
        ///</Summary>
        [JsonPropertyName("discount")]
        public float Discount { get; set; }

        ///<Summary>
        ///本币单价
        ///</Summary>
        [JsonPropertyName("natprice")]
        public float Natprice { get; set; }

        ///<Summary>
        ///本币金额
        ///</Summary>
        [JsonPropertyName("natmoney")]
        public float Natmoney { get; set; }

        ///<Summary>
        ///辅计量单位编码
        ///</Summary>
        [JsonPropertyName("assistantunit")]
        public string Assistantunit { get; set; }

        ///<Summary>
        ///本币税额
        ///</Summary>
        [JsonPropertyName("nattax")]
        public float Nattax { get; set; }

        ///<Summary>
        ///本币价税合计
        ///</Summary>
        [JsonPropertyName("natsum")]
        public float Natsum { get; set; }

        ///<Summary>
        ///本币折扣额
        ///</Summary>
        [JsonPropertyName("natdiscount")]
        public float Natdiscount { get; set; }

        ///<Summary>
        ///税率
        ///</Summary>
        [JsonPropertyName("taxrate")]
        public float Taxrate { get; set; }

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