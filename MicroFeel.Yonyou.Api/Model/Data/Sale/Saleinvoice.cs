using System;using System.Collections.Generic;using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Saleinvoice
    {
        ///<Summary>
        ///发票号
        ///</Summary>
        [JsonPropertyName("invoiceno")]
        public string Invoiceno { get; set; }
        ///<Summary>
        ///单据类型
        ///</Summary>
        [JsonPropertyName("vouchertype")]
        public string Vouchertype { get; set; }
        ///<Summary>
        ///销售类型编号
        ///</Summary>
        [JsonPropertyName("saletypecode")]
        public string Saletypecode { get; set; }
        ///<Summary>
        ///日期
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
        ///客商编号
        ///</Summary>
        [JsonPropertyName("customercode")]
        public string Customercode { get; set; }
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
        ///备注
        ///</Summary>
        [JsonPropertyName("memory")]
        public string Memory { get; set; }
        ///<Summary>
        ///汇率
        ///</Summary>
        [JsonPropertyName("currencyrate")]
        public float Currencyrate { get; set; }
        ///<Summary>
        ///税率
        ///</Summary>
        [JsonPropertyName("taxrate")]
        public float Taxrate { get; set; }
        ///<Summary>
        ///负发票-正发票
        ///</Summary>
        [JsonPropertyName("isnegative")]
        public bool Isnegative { get; set; }
        ///<Summary>
        ///本单位开户银行编号
        ///</Summary>
        [JsonPropertyName("bankcode")]
        public string Bankcode { get; set; }
        ///<Summary>
        ///发票版别
        ///</Summary>
        [JsonPropertyName("invoiceversion")]
        public string Invoiceversion { get; set; }
        ///<Summary>
        ///制单人
        ///</Summary>
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        ///<Summary>
        ///业务类型
        ///</Summary>
        [JsonPropertyName("businesstype")]
        public string Businesstype { get; set; }
        ///<Summary>
        ///是否期初
        ///</Summary>
        [JsonPropertyName("isfirst")]
        public bool Isfirst { get; set; }
        ///<Summary>
        ///项目大类编号
        ///</Summary>
        [JsonPropertyName("itemclasscode")]
        public string Itemclasscode { get; set; }
        ///<Summary>
        ///项目编码
        ///</Summary>
        [JsonPropertyName("itemcode")]
        public string Itemcode { get; set; }
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
        ///自定义项11
        ///</Summary>
        [JsonPropertyName("define11")]
        public string Define11 { get; set; }
        ///<Summary>
        ///自定义项12
        ///</Summary>
        [JsonPropertyName("define12")]
        public string Define12 { get; set; }
        ///<Summary>
        ///自定义项13
        ///</Summary>
        [JsonPropertyName("define13")]
        public string Define13 { get; set; }
        ///<Summary>
        ///自定义项14
        ///</Summary>
        [JsonPropertyName("define14")]
        public string Define14 { get; set; }
        ///<Summary>
        ///自定义项15
        ///</Summary>
        [JsonPropertyName("define15")]
        public string Define15 { get; set; }
        ///<Summary>
        ///自定义项16
        ///</Summary>
        [JsonPropertyName("define16")]
        public string Define16 { get; set; }
        ///<Summary>
        ///1先发货；0先开票
        ///</Summary>
        [JsonPropertyName("ispayedfirst")]
        public float Ispayedfirst { get; set; }
        ///<Summary>
        ///综合开票客户名称
        ///</Summary>
        [JsonPropertyName("customername")]
        public string Customername { get; set; }
        ///<Summary>
        ///客户账号
        ///</Summary>
        [JsonPropertyName("ccusaccount")]
        public string Ccusaccount { get; set; }
        ///<Summary>
        ///本单位账号
        ///</Summary>
        [JsonPropertyName("cbaccount")]
        public string Cbaccount { get; set; }
        ///<Summary>
        ///收货单位名称
        ///</Summary>
        [JsonPropertyName("cdeliverunit")]
        public string Cdeliverunit { get; set; }
        ///<Summary>
        ///收货地址
        ///</Summary>
        [JsonPropertyName("cdeliveradd")]
        public string Cdeliveradd { get; set; }
        ///<Summary>
        ///收货联系人
        ///</Summary>
        [JsonPropertyName("ccontactname")]
        public string Ccontactname { get; set; }
        ///<Summary>
        ///收货联系电话
        ///</Summary>
        [JsonPropertyName("cofficephone")]
        public string Cofficephone { get; set; }
        ///<Summary>
        ///收货联系手机
        ///</Summary>
        [JsonPropertyName("cmobilephone")]
        public string Cmobilephone { get; set; }
        ///<Summary>
        ///收获地址编码
        ///</Summary>
        [JsonPropertyName("caddcode")]
        public string Caddcode { get; set; }
        ///<Summary>
        ///收付款协议编码
        ///</Summary>
        [JsonPropertyName("cgatheringplan")]
        public string Cgatheringplan { get; set; }
        ///<Summary>
        ///立账日
        ///</Summary>
        [JsonPropertyName("dcreditstart")]
        public DateTime Dcreditstart { get; set; }
        ///<Summary>
        ///账期
        ///</Summary>
        [JsonPropertyName("icreditdays")]
        public float Icreditdays { get; set; }
        ///<Summary>
        ///到期日
        ///</Summary>
        [JsonPropertyName("dgatheringdate")]
        public DateTime Dgatheringdate { get; set; }
        ///<Summary>
        ///是否立账单据
        ///</Summary>
        [JsonPropertyName("bcredit")]
        public bool Bcredit { get; set; }
        ///<Summary>
        ///来源
        ///</Summary>
        [JsonPropertyName("csource")]
        public string Csource { get; set; }
        ///<Summary>
        ///客户开户银行
        ///</Summary>
        [JsonPropertyName("ccusbank")]
        public string Ccusbank { get; set; }
        ///<Summary>
        ///仓库编码
        ///</Summary>
        [JsonPropertyName("entry")]
        public IList<SaleinvoiceEntry> Saleinvoiceentry { get; set; }
    }

    public class SaleinvoiceEntry
    {

        ///<Summary>
        ///仓库编码
        ///</Summary>
        [JsonPropertyName("warehousecode")]
        public string Warehousecode { get; set; }

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
        ///件数
        ///</Summary>
        [JsonPropertyName("number")]
        public float Number { get; set; }

        ///<Summary>
        ///报价
        ///</Summary>
        [JsonPropertyName("quotedprice")]
        public float Quotedprice { get; set; }

        ///<Summary>
        ///无税单价
        ///</Summary>
        [JsonPropertyName("originalprice")]
        public float Originalprice { get; set; }

        ///<Summary>
        ///含税单价
        ///</Summary>
        [JsonPropertyName("originaltaxedprice")]
        public float Originaltaxedprice { get; set; }

        ///<Summary>
        ///无税金额
        ///</Summary>
        [JsonPropertyName("originalmoney")]
        public float Originalmoney { get; set; }

        ///<Summary>
        ///税额
        ///</Summary>
        [JsonPropertyName("originaltax")]
        public float Originaltax { get; set; }

        ///<Summary>
        ///价税合计
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
        ///销售单位编码
        ///</Summary>
        [JsonPropertyName("assistantunit")]
        public string Assistantunit { get; set; }

        ///<Summary>
        ///折扣额
        ///</Summary>
        [JsonPropertyName("originaldiscount")]
        public float Originaldiscount { get; set; }

        ///<Summary>
        ///本币折扣额
        ///</Summary>
        [JsonPropertyName("discount")]
        public float Discount { get; set; }


        ///<Summary>
        ///批号
        ///</Summary>
        [JsonPropertyName("serial")]
        public string Serial { get; set; }

        ///<Summary>
        ///扣率（%）
        ///</Summary>
        [JsonPropertyName("accountrate1")]
        public float Accountrate1 { get; set; }

        ///<Summary>
        ///扣率2（%）
        ///</Summary>
        [JsonPropertyName("accountrate2")]
        public float Accountrate2 { get; set; }

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
        ///零售单价
        ///</Summary>
        [JsonPropertyName("retailprice")]
        public float Retailprice { get; set; }

        ///<Summary>
        ///零售金额
        ///</Summary>
        [JsonPropertyName("retailmoney")]
        public float Retailmoney { get; set; }



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
        ///批次属性1
        ///</Summary>
        [JsonPropertyName("batchproperty1")]
        public string Batchproperty1 { get; set; }

        ///<Summary>
        ///批次属性2
        ///</Summary>
        [JsonPropertyName("batchproperty2")]
        public string Batchproperty2 { get; set; }

        ///<Summary>
        ///批次属性3
        ///</Summary>
        [JsonPropertyName("batchproperty3")]
        public string Batchproperty3 { get; set; }

        ///<Summary>
        ///批次属性4
        ///</Summary>
        [JsonPropertyName("batchproperty4")]
        public string Batchproperty4 { get; set; }

        ///<Summary>
        ///批次属性5
        ///</Summary>
        [JsonPropertyName("batchproperty5")]
        public string Batchproperty5 { get; set; }

        ///<Summary>
        ///批次属性6
        ///</Summary>
        [JsonPropertyName("batchproperty6")]
        public string Batchproperty6 { get; set; }

        ///<Summary>
        ///批次属性7
        ///</Summary>
        [JsonPropertyName("batchproperty7")]
        public string Batchproperty7 { get; set; }

        ///<Summary>
        ///批次属性8
        ///</Summary>
        [JsonPropertyName("batchproperty8")]
        public string Batchproperty8 { get; set; }

        ///<Summary>
        ///批次属性9
        ///</Summary>
        [JsonPropertyName("batchproperty9")]
        public string Batchproperty9 { get; set; }

        ///<Summary>
        ///批次属性10
        ///</Summary>
        [JsonPropertyName("batchproperty10")]
        public string Batchproperty10 { get; set; }

        ///<Summary>
        ///换算率
        ///</Summary>
        [JsonPropertyName("exchangerate")]
        public float Exchangerate { get; set; }

        ///<Summary>
        ///销售单位编码
        ///</Summary>
        [JsonPropertyName("unitid")]
        public string Unitid { get; set; }

        ///<Summary>
        ///保质期单位
        ///</Summary>
        [JsonPropertyName("cmassunit")]
        public string Cmassunit { get; set; }

        ///<Summary>
        ///保质期
        ///</Summary>
        [JsonPropertyName("imassdate")]
        public float Imassdate { get; set; }

        ///<Summary>
        ///生产日期
        ///</Summary>
        [JsonPropertyName("dmdate")]
        public DateTime Dmdate { get; set; }

        ///<Summary>
        ///失效日期
        ///</Summary>
        [JsonPropertyName("invaliddate")]
        public DateTime Invaliddate { get; set; }

        ///<Summary>
        ///有效期至
        ///</Summary>
        [JsonPropertyName("expirationdate")]
        public string Expirationdate { get; set; }

        ///<Summary>
        ///有效期推算方式
        ///</Summary>
        [JsonPropertyName("expiratdatecalcu")]
        public float Expiratdatecalcu { get; set; }

        ///<Summary>
        ///有效期计算项
        ///</Summary>
        [JsonPropertyName("expirationitem")]
        public DateTime Expirationitem { get; set; }

        ///<Summary>
        ///供货商编码
        ///</Summary>
        [JsonPropertyName("cvmivencode")]
        public string Cvmivencode { get; set; }

        ///<Summary>
        ///行号
        ///</Summary>
        [JsonPropertyName("irowno")]
        public float Irowno { get; set; }

        ///<Summary>
        ///退货原因编码
        ///</Summary>
        [JsonPropertyName("reasoncode")]
        public string Reasoncode { get; set; }

        ///<Summary>
        ///报价含税
        ///</Summary>
        [JsonPropertyName("bsaleprice")]
        public bool Bsaleprice { get; set; }

        ///<Summary>
        ///赠品
        ///</Summary>
        [JsonPropertyName("bgift")]
        public bool Bgift { get; set; }

        ///<Summary>
        ///最低售价
        ///</Summary>
        [JsonPropertyName("fcusminprice")]
        public float Fcusminprice { get; set; }

        ///<Summary>
        ///发货模式
        ///</Summary>
        [JsonPropertyName("icalctype")]
        public float Icalctype { get; set; }

        ///<Summary>
        ///使用数量
        ///</Summary>
        [JsonPropertyName("fchildqty")]
        public float Fchildqty { get; set; }

        ///<Summary>
        ///权重比例
        ///</Summary>
        [JsonPropertyName("fchildrate")]
        public float Fchildrate { get; set; }

    }

}