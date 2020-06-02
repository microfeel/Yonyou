using System;using System.Collections.Generic;using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Purchasereturn
    {
    ///<Summary>
    ///单据号
    ///</Summary>
    [JsonPropertyName("code")]
    public string Code { get;set; }
    ///<Summary>
    ///采购类型编码
    ///</Summary>
    [JsonPropertyName("purchasetypecode")]
    public string Purchasetypecode { get;set; }
    ///<Summary>
    ///采购类型
    ///</Summary>
    [JsonPropertyName("purchasetypename")]
    public string Purchasetypename { get;set; }
    ///<Summary>
    ///供货单位编号
    ///</Summary>
    [JsonPropertyName("vendorcode")]
    public string Vendorcode { get;set; }
    ///<Summary>
    ///供应商
    ///</Summary>
    [JsonPropertyName("vendorabbname")]
    public string Vendorabbname { get;set; }
    ///<Summary>
    ///供应商全称
    ///</Summary>
    [JsonPropertyName("vendorname")]
    public string Vendorname { get;set; }
    ///<Summary>
    ///部门编号
    ///</Summary>
    [JsonPropertyName("departmentcode")]
    public string Departmentcode { get;set; }
    ///<Summary>
    ///部门
    ///</Summary>
    [JsonPropertyName("departmentname")]
    public string Departmentname { get;set; }
    ///<Summary>
    ///业务员编码
    ///</Summary>
    [JsonPropertyName("personcode")]
    public string Personcode { get;set; }
    ///<Summary>
    ///业务员
    ///</Summary>
    [JsonPropertyName("personname")]
    public string Personname { get;set; }
    ///<Summary>
    ///付款条件编码
    ///</Summary>
    [JsonPropertyName("payconditioncode")]
    public string Payconditioncode { get;set; }
    ///<Summary>
    ///付款条件
    ///</Summary>
    [JsonPropertyName("payconditionname")]
    public string Payconditionname { get;set; }
    ///<Summary>
    ///币种
    ///</Summary>
    [JsonPropertyName("foreigncurrency")]
    public string Foreigncurrency { get;set; }
    ///<Summary>
    ///币种编码
    ///</Summary>
    [JsonPropertyName("cexch_code")]
    public string CexchCode { get;set; }
    ///<Summary>
    ///汇率
    ///</Summary>
    [JsonPropertyName("foreigncurrencyrate")]
    public float Foreigncurrencyrate { get;set; }
    ///<Summary>
    ///备注
    ///</Summary>
    [JsonPropertyName("memory")]
    public string Memory { get;set; }
    ///<Summary>
    ///业务类型
    ///</Summary>
    [JsonPropertyName("businesstype")]
    public string Businesstype { get;set; }
    ///<Summary>
    ///制单人
    ///</Summary>
    [JsonPropertyName("maker")]
    public string Maker { get;set; }
    ///<Summary>
    ///关闭人
    ///</Summary>
    [JsonPropertyName("ccloser")]
    public string Ccloser { get;set; }
    ///<Summary>
    ///扣税类别
    ///</Summary>
    [JsonPropertyName("idiscounttaxtype")]
    public float Idiscounttaxtype { get;set; }
    ///<Summary>
    ///表头自定义项1
    ///</Summary>
    [JsonPropertyName("define1")]
    public string Define1 { get;set; }
    ///<Summary>
    ///表头自定义项2
    ///</Summary>
    [JsonPropertyName("define2")]
    public string Define2 { get;set; }
    ///<Summary>
    ///表头自定义项3
    ///</Summary>
    [JsonPropertyName("define3")]
    public string Define3 { get;set; }
    ///<Summary>
    ///表头自定义项4
    ///</Summary>
    [JsonPropertyName("define4")]
    public DateTime Define4 { get;set; }
    ///<Summary>
    ///表头自定义项5
    ///</Summary>
    [JsonPropertyName("define5")]
    public float Define5 { get;set; }
    ///<Summary>
    ///表头自定义项6
    ///</Summary>
    [JsonPropertyName("define6")]
    public DateTime Define6 { get;set; }
    ///<Summary>
    ///表头自定义项7
    ///</Summary>
    [JsonPropertyName("define7")]
    public float Define7 { get;set; }
    ///<Summary>
    ///表头自定义项8
    ///</Summary>
    [JsonPropertyName("define8")]
    public string Define8 { get;set; }
    ///<Summary>
    ///表头自定义项9
    ///</Summary>
    [JsonPropertyName("define9")]
    public string Define9 { get;set; }
    ///<Summary>
    ///表头自定义项10
    ///</Summary>
    [JsonPropertyName("define10")]
    public string Define10 { get;set; }
    ///<Summary>
    ///表头自定义项11
    ///</Summary>
    [JsonPropertyName("define11")]
    public string Define11 { get;set; }
    ///<Summary>
    ///表头自定义项12
    ///</Summary>
    [JsonPropertyName("define12")]
    public string Define12 { get;set; }
    ///<Summary>
    ///表头自定义项13
    ///</Summary>
    [JsonPropertyName("define13")]
    public string Define13 { get;set; }
    ///<Summary>
    ///表头自定义项14
    ///</Summary>
    [JsonPropertyName("define14")]
    public string Define14 { get;set; }
    ///<Summary>
    ///表头自定义项15
    ///</Summary>
    [JsonPropertyName("define15")]
    public float Define15 { get;set; }
    ///<Summary>
    ///表头自定义项16
    ///</Summary>
    [JsonPropertyName("define16")]
    public float Define16 { get;set; }
    ///<Summary>
    ///运输方式编码
    ///</Summary>
    [JsonPropertyName("shipcode")]
    public string Shipcode { get;set; }
    ///<Summary>
    ///运输方式
    ///</Summary>
    [JsonPropertyName("shipname")]
    public string Shipname { get;set; }
    ///<Summary>
    ///(0到货单,1退货单)
    ///</Summary>
    [JsonPropertyName("billtype")]
    public int Billtype { get;set; }
    ///<Summary>
    ///单据类型
    ///</Summary>
    [JsonPropertyName("cvouchtype")]
    public string Cvouchtype { get;set; }
    ///<Summary>
    ///修改日期
    ///</Summary>
    [JsonPropertyName("cmodifydate")]
    public DateTime Cmodifydate { get;set; }
    ///<Summary>
    ///修改人
    ///</Summary>
    [JsonPropertyName("creviser")]
    public string Creviser { get;set; }
    ///<Summary>
    ///审核日期
    ///</Summary>
    [JsonPropertyName("cauditdate")]
    public DateTime Cauditdate { get;set; }
    ///<Summary>
    ///审核人
    ///</Summary>
    [JsonPropertyName("cverifier")]
    public string Cverifier { get;set; }
    ///<Summary>
    ///收付款协议编码
    ///</Summary>
    [JsonPropertyName("cvenpuomprotocol")]
    public string Cvenpuomprotocol { get;set; }
    ///<Summary>
    ///收付款协议名称
    ///</Summary>
    [JsonPropertyName("cvenpuomprotocolname")]
    public string Cvenpuomprotocolname { get;set; }
    ///<Summary>
    ///单据条码
    ///</Summary>
    [JsonPropertyName("csysbarcode")]
    public string Csysbarcode { get;set; }
    ///<Summary>
    ///仓库编码
    ///</Summary>
    [JsonPropertyName("entry")]
    public IList<PurchasereturnEntry> Purchasereturnentry { get;set; }	}

    public class PurchasereturnEntry
    {
        
///<Summary>
///仓库编码
///</Summary>
[JsonPropertyName("warehousecode")]
public string Warehousecode { get;set; }
        
///<Summary>
///仓库名称
///</Summary>
[JsonPropertyName("warehousename")]
public string Warehousename { get;set; }
        
///<Summary>
///存货编码
///</Summary>
[JsonPropertyName("inventorycode")]
public string Inventorycode { get;set; }
        
///<Summary>
///存货代码
///</Summary>
[JsonPropertyName("inventoryaddcode")]
public string Inventoryaddcode { get;set; }
        
///<Summary>
///存货名称
///</Summary>
[JsonPropertyName("inventoryname")]
public string Inventoryname { get;set; }
        
///<Summary>
///规格型号
///</Summary>
[JsonPropertyName("inventorystd")]
public string Inventorystd { get;set; }
        
///<Summary>
///存货分类编码
///</Summary>
[JsonPropertyName("inventoryclasscode")]
public string Inventoryclasscode { get;set; }
        
///<Summary>
///单位编码
///</Summary>
[JsonPropertyName("unitid")]
public string Unitid { get;set; }
        
///<Summary>
///单位编码
///</Summary>
[JsonPropertyName("ccomunitcode")]
public string Ccomunitcode { get;set; }
        
///<Summary>
///主计量
///</Summary>
[JsonPropertyName("cinvm_unit")]
public string CinvmUnit { get;set; }
        
///<Summary>
///采购单位
///</Summary>
[JsonPropertyName("cinva_unit")]
public string CinvaUnit { get;set; }
        
///<Summary>
///换算率
///</Summary>
[JsonPropertyName("iinvexchrate")]
public float Iinvexchrate { get;set; }
        
///<Summary>
///批号
///</Summary>
[JsonPropertyName("serial")]
public string Serial { get;set; }
        
///<Summary>
///关闭人
///</Summary>
[JsonPropertyName("closer")]
public string Closer { get;set; }
        
///<Summary>
///含税单价
///</Summary>
[JsonPropertyName("originaltaxedprice")]
public float Originaltaxedprice { get;set; }
        
///<Summary>
///主计量数量
///</Summary>
[JsonPropertyName("quantity")]
public float Quantity { get;set; }
        
///<Summary>
///件数
///</Summary>
[JsonPropertyName("number")]
public float Number { get;set; }
        
///<Summary>
///原币单价
///</Summary>
[JsonPropertyName("originalprice")]
public float Originalprice { get;set; }
        
///<Summary>
///原币金额
///</Summary>
[JsonPropertyName("originalmoney")]
public float Originalmoney { get;set; }
        
///<Summary>
///原币税额
///</Summary>
[JsonPropertyName("originaltax")]
public float Originaltax { get;set; }
        
///<Summary>
///原币价税合计
///</Summary>
[JsonPropertyName("originalsum")]
public float Originalsum { get;set; }
        
///<Summary>
///本币单价
///</Summary>
[JsonPropertyName("price")]
public float Price { get;set; }
        
///<Summary>
///本币金额
///</Summary>
[JsonPropertyName("money")]
public float Money { get;set; }
        
///<Summary>
///本币税额
///</Summary>
[JsonPropertyName("tax")]
public float Tax { get;set; }
        
///<Summary>
///本币价税合计
///</Summary>
[JsonPropertyName("sum")]
public float Sum { get;set; }
        
///<Summary>
///行关闭人
///</Summary>
[JsonPropertyName("cbcloser")]
public string Cbcloser { get;set; }
        
///<Summary>
///自由项1
///</Summary>
[JsonPropertyName("free1")]
public string Free1 { get;set; }
        
///<Summary>
///自由项2
///</Summary>
[JsonPropertyName("free2")]
public string Free2 { get;set; }
        
///<Summary>
///表体自定义项1
///</Summary>
[JsonPropertyName("define22")]
public string Define22 { get;set; }
        
///<Summary>
///表体自定义项2
///</Summary>
[JsonPropertyName("define23")]
public string Define23 { get;set; }
        
///<Summary>
///表体自定义项3
///</Summary>
[JsonPropertyName("define24")]
public string Define24 { get;set; }
        
///<Summary>
///表体自定义项4
///</Summary>
[JsonPropertyName("define25")]
public string Define25 { get;set; }
        
///<Summary>
///表体自定义项5
///</Summary>
[JsonPropertyName("define26")]
public float Define26 { get;set; }
        
///<Summary>
///表体自定义项6
///</Summary>
[JsonPropertyName("define27")]
public float Define27 { get;set; }
        
///<Summary>
///表体自定义项7
///</Summary>
[JsonPropertyName("define28")]
public string Define28 { get;set; }
        
///<Summary>
///表体自定义项8
///</Summary>
[JsonPropertyName("define29")]
public string Define29 { get;set; }
        
///<Summary>
///表体自定义项9
///</Summary>
[JsonPropertyName("define30")]
public string Define30 { get;set; }
        
///<Summary>
///表体自定义项10
///</Summary>
[JsonPropertyName("define31")]
public string Define31 { get;set; }
        
///<Summary>
///表体自定义项11
///</Summary>
[JsonPropertyName("define32")]
public string Define32 { get;set; }
        
///<Summary>
///表体自定义项12
///</Summary>
[JsonPropertyName("define33")]
public string Define33 { get;set; }
        
///<Summary>
///表体自定义项13
///</Summary>
[JsonPropertyName("define34")]
public float Define34 { get;set; }
        
///<Summary>
///表体自定义项14
///</Summary>
[JsonPropertyName("define35")]
public float Define35 { get;set; }
        
///<Summary>
///表体自定义项15
///</Summary>
[JsonPropertyName("define36")]
public DateTime Define36 { get;set; }
        
///<Summary>
///表体自定义项16
///</Summary>
[JsonPropertyName("define37")]
public DateTime Define37 { get;set; }
        
///<Summary>
///税率
///</Summary>
[JsonPropertyName("taxrate")]
public float Taxrate { get;set; }
        
///<Summary>
///订单子表ID
///</Summary>
[JsonPropertyName("iposid")]
public float Iposid { get;set; }
        
///<Summary>
///自由项3
///</Summary>
[JsonPropertyName("free3")]
public string Free3 { get;set; }
        
///<Summary>
///自由项4
///</Summary>
[JsonPropertyName("free4")]
public string Free4 { get;set; }
        
///<Summary>
///自由项5
///</Summary>
[JsonPropertyName("free5")]
public string Free5 { get;set; }
        
///<Summary>
///自由项6
///</Summary>
[JsonPropertyName("free6")]
public string Free6 { get;set; }
        
///<Summary>
///自由项7
///</Summary>
[JsonPropertyName("free7")]
public string Free7 { get;set; }
        
///<Summary>
///自由项8
///</Summary>
[JsonPropertyName("free8")]
public string Free8 { get;set; }
        
///<Summary>
///自由项9
///</Summary>
[JsonPropertyName("free9")]
public string Free9 { get;set; }
        
///<Summary>
///自由项10
///</Summary>
[JsonPropertyName("free10")]
public string Free10 { get;set; }
        
        
        
///<Summary>
///订单号
///</Summary>
[JsonPropertyName("cordercode")]
public string Cordercode { get;set; }
        
///<Summary>
///单据状态
///</Summary>
[JsonPropertyName("vouchstate")]
public float Vouchstate { get;set; }
        
///<Summary>
///行号
///</Summary>
[JsonPropertyName("ivouchrowno")]
public float Ivouchrowno { get;set; }
        
///<Summary>
///表体备注
///</Summary>
[JsonPropertyName("cbmemo")]
public string Cbmemo { get;set; }
        
///<Summary>
///行条码
///</Summary>
[JsonPropertyName("cbsysbarcode")]
public string Cbsysbarcode { get;set; }

    }

}