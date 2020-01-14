using System;using System.Collections.Generic;using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Returnorder
    {
        ///<Summary>
        ///单据号
        ///</Summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        ///<Summary>
        ///单据日期
        ///</Summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        ///<Summary>
        ///业务类型
        ///</Summary>
        [JsonPropertyName("operation_type")]
        public string OperationType { get; set; }
        ///<Summary>
        ///销售类型编码
        ///</Summary>
        [JsonPropertyName("saletype")]
        public string Saletype { get; set; }
        ///<Summary>
        ///销售类型
        ///</Summary>
        [JsonPropertyName("saletypename")]
        public string Saletypename { get; set; }
        ///<Summary>
        ///订单状态
        ///</Summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
        ///<Summary>
        ///客户编码
        ///</Summary>
        [JsonPropertyName("custcode")]
        public string Custcode { get; set; }
        ///<Summary>
        ///客户
        ///</Summary>
        [JsonPropertyName("cusname")]
        public string Cusname { get; set; }
        ///<Summary>
        ///客户简称
        ///</Summary>
        [JsonPropertyName("cusabbname")]
        public string Cusabbname { get; set; }
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
        ///人员编码
        ///</Summary>
        [JsonPropertyName("personcode")]
        public string Personcode { get; set; }
        ///<Summary>
        ///人员
        ///</Summary>
        [JsonPropertyName("personname")]
        public string Personname { get; set; }
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
        public IList<ReturnorderEntry> Returnorderentry { get; set; }
    }

    public class ReturnorderEntry
    {

        ///<Summary>
        ///存货编码
        ///</Summary>
        [JsonPropertyName("inventory_code")]
        public string InventoryCode { get; set; }

        ///<Summary>
        ///存货名称
        ///</Summary>
        [JsonPropertyName("inventory_name")]
        public string InventoryName { get; set; }

        ///<Summary>
        ///仓库编码
        ///</Summary>
        [JsonPropertyName("warehouse_code")]
        public string WarehouseCode { get; set; }

        ///<Summary>
        ///仓库名称
        ///</Summary>
        [JsonPropertyName("warehouse_name")]
        public string WarehouseName { get; set; }

        ///<Summary>
        ///存货规格
        ///</Summary>
        [JsonPropertyName("invstd")]
        public string Invstd { get; set; }

        ///<Summary>
        ///主计量单位编码
        ///</Summary>
        [JsonPropertyName("ccomunitcode")]
        public string Ccomunitcode { get; set; }

        ///<Summary>
        ///主计量单位
        ///</Summary>
        [JsonPropertyName("cinvm_unit")]
        public string CinvmUnit { get; set; }

        ///<Summary>
        ///数量
        ///</Summary>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        ///<Summary>
        ///单价，传入会自动重新计算相关价格及金额。如果传入了含税单价，以含税单价为准自动计算。
        ///</Summary>
        [JsonPropertyName("price")]
        public float Price { get; set; }

        ///<Summary>
        ///报价
        ///</Summary>
        [JsonPropertyName("quotedprice")]
        public float Quotedprice { get; set; }

        ///<Summary>
        ///含税单价，传入会自动重新计算相关价格及金额。
        ///</Summary>
        [JsonPropertyName("taxprice")]
        public float Taxprice { get; set; }

        ///<Summary>
        ///无税金额
        ///</Summary>
        [JsonPropertyName("money")]
        public float Money { get; set; }

        ///<Summary>
        ///价税合计
        ///</Summary>
        [JsonPropertyName("sum")]
        public float Sum { get; set; }

        ///<Summary>
        ///税率
        ///</Summary>
        [JsonPropertyName("taxrate")]
        public float Taxrate { get; set; }

        ///<Summary>
        ///税额
        ///</Summary>
        [JsonPropertyName("tax")]
        public float Tax { get; set; }

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
        ///折扣额
        ///</Summary>
        [JsonPropertyName("discount")]
        public float Discount { get; set; }

        ///<Summary>
        ///本币折扣额
        ///</Summary>
        [JsonPropertyName("natdiscount")]
        public float Natdiscount { get; set; }

        ///<Summary>
        ///扣率（%）
        ///</Summary>
        [JsonPropertyName("discount1")]
        public float Discount1 { get; set; }

        ///<Summary>
        ///扣率2（%）
        ///</Summary>
        [JsonPropertyName("discount2")]
        public float Discount2 { get; set; }

        ///<Summary>
        ///销售订单号
        ///</Summary>
        [JsonPropertyName("socode")]
        public string Socode { get; set; }

        ///<Summary>
        ///退货原因编码
        ///</Summary>
        [JsonPropertyName("reasoncode")]
        public string Reasoncode { get; set; }

        ///<Summary>
        ///退货原因
        ///</Summary>
        [JsonPropertyName("reasonname")]
        public string Reasonname { get; set; }

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