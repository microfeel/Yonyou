using System;
using System.Collections.Generic;

namespace MicroFeel.Yonyou.Api
{
    public class Saleout
    { 
        ///<summary>
        ///业务类型
        ///</summary>
        public string Businesstype { get; set; }
        ///<summary>
        ///单据来源
        ///</summary>
        public string Source { get; set; }
        ///<summary>
        ///对应业务单号
        ///</summary>
        public string Businesscode { get; set; }
        ///<summary>
        ///仓库编码
        ///</summary>
        public string Warehousecode { get; set; }
        ///<summary>
        ///仓库名称
        ///</summary>
        public string Warehousename { get; set; }
        ///<summary>
        ///单据日期
        ///</summary>
        public string Date { get; set; }
        ///<summary>
        ///单据号
        ///</summary>
        public string Code { get; set; }
        ///<summary>
        ///收发类别编码
        ///</summary>
        public string Receivecode { get; set; }
        ///<summary>
        ///收发类别名称
        ///</summary>
        public string Receivename { get; set; }
        ///<summary>
        ///部门编码
        ///</summary>
        public string Departmentcode { get; set; }
        ///<summary>
        ///部门名称
        ///</summary>
        public string Departmentname { get; set; }
        ///<summary>
        ///业务员编码
        ///</summary>
        public string Personcode { get; set; }
        ///<summary>
        ///销售类型编码
        ///</summary>
        public string Saletypecode { get; set; }
        ///<summary>
        ///客户编码
        ///</summary>
        public string Customercode { get; set; }
        ///<summary>
        ///供应商编码
        ///</summary>
        public string Vendorcode { get; set; }
        ///<summary>
        ///到货日期
        ///</summary>
        public string Arrivedate { get; set; }
        ///<summary>
        ///审核人
        ///</summary>
        public string Handler { get; set; }
        ///<summary>
        ///备注
        ///</summary>
        public string Memory { get; set; }
        ///<summary>
        ///制单人
        ///</summary>
        public string Maker { get; set; }
        ///<summary>
        ///自定义项1
        ///</summary>
        public string Define1 { get; set; }
        ///<summary>
        ///自定义项2
        ///</summary>
        public string Define2 { get; set; }
        ///<summary>
        ///自定义项3
        ///</summary>
        public string Define3 { get; set; }
        ///<summary>
        ///自定义项4
        ///</summary>
        public DateTime Define4 { get; set; }
        ///<summary>
        ///自定义项5
        ///</summary>
        public float Define5 { get; set; }
        ///<summary>
        ///自定义项6
        ///</summary>
        public DateTime Define6 { get; set; }
        ///<summary>
        ///自定义项7
        ///</summary>
        public float Define7 { get; set; }
        ///<summary>
        ///自定义项8
        ///</summary>
        public string Define8 { get; set; }
        ///<summary>
        ///自定义项9
        ///</summary>
        public string Define9 { get; set; }
        ///<summary>
        ///自定义项10
        ///</summary>
        public string Define10 { get; set; }
        ///<summary>
        ///自定义项11
        ///</summary>
        public string Define11 { get; set; }
        ///<summary>
        ///自定义项12
        ///</summary>
        public string Define12 { get; set; }
        ///<summary>
        ///自定义项13
        ///</summary>
        public string Define13 { get; set; }
        ///<summary>
        ///自定义项14
        ///</summary>
        public string Define14 { get; set; }
        ///<summary>
        ///自定义项15
        ///</summary>
        public float Define15 { get; set; }
        ///<summary>
        ///自定义项16
        ///</summary>
        public float Define16 { get; set; }
        ///<summary>
        ///审核日期
        ///</summary>
        public string Auditdate { get; set; }
        ///<summary>
        ///业务员名称
        ///</summary>
        public string Personname { get; set; }
        ///<summary>
        ///销售类型名称
        ///</summary>
        public string Saletypename { get; set; }
        ///<summary>
        ///客户名称
        ///</summary>
        public string Customername { get; set; }
        ///<summary>
        ///时间戳
        ///</summary>
        public float Timestamp { get; set; }
        ///<summary>
        ///条形码
        ///</summary>
        public IList<SaleoutEntry> Saleoutentry { get; set; }


    }

    public class SaleoutEntry
    {
        ///<summary>
        ///条形码
        ///</summary>
        public string Barcode { get; set; }
        ///<summary>
        ///存货编码
        ///</summary>
        public string Inventorycode { get; set; }
        ///<summary>
        ///存货自由项1
        ///</summary>
        public string Free1 { get; set; }
        ///<summary>
        ///存货自由项2
        ///</summary>
        public string Free2 { get; set; }
        ///<summary>
        ///存货自由项3
        ///</summary>
        public string Free3 { get; set; }
        ///<summary>
        ///存货自由项4
        ///</summary>
        public string Free4 { get; set; }
        ///<summary>
        ///存货自由项5
        ///</summary>
        public string Free5 { get; set; }
        ///<summary>
        ///存货自由项6
        ///</summary>
        public string Free6 { get; set; }
        ///<summary>
        ///存货自由项7
        ///</summary>
        public string Free7 { get; set; }
        ///<summary>
        ///存货自由项8
        ///</summary>
        public string Free8 { get; set; }
        ///<summary>
        ///存货自由项9
        ///</summary>
        public string Free9 { get; set; }
        ///<summary>
        ///存货自由项10
        ///</summary>
        public string Free10 { get; set; }
        ///<summary>
        ///应发数量
        ///</summary>
        public float Shouldquantity { get; set; }
        ///<summary>
        ///应发件数
        ///</summary>
        public float Shouldnumber { get; set; }
        ///<summary>
        ///数量
        ///</summary>
        public float Quantity { get; set; }
        ///<summary>
        ///主计量单位
        ///</summary>
        public string Cmassunitname { get; set; }
        ///<summary>
        ///库存单位码
        ///</summary>
        public string Assitantunit { get; set; }
        ///<summary>
        ///库存单位
        ///</summary>
        public string Assitantunitname { get; set; }
        ///<summary>
        ///换算率
        ///</summary>
        public float Irate { get; set; }
        ///<summary>
        ///件数
        ///</summary>
        public float Number { get; set; }
        ///<summary>
        ///单价
        ///</summary>
        public float Price { get; set; }
        ///<summary>
        ///金额
        ///</summary>
        public float Cost { get; set; }
        ///<summary>
        ///批号
        ///</summary>
        public string Serial { get; set; }
        ///<summary>
        ///生产日期
        ///</summary>
        public DateTime Makedate { get; set; }
        ///<summary>
        ///失效日期
        ///</summary>
        public DateTime Validdate { get; set; }
        ///<summary>
        ///表体自定义项1
        ///</summary>
        public string Define22 { get; set; }
        ///<summary>
        ///表体自定义项2
        ///</summary>
        public string Define23 { get; set; }
        ///<summary>
        ///表体自定义项3
        ///</summary>
        public string Define24 { get; set; }
        ///<summary>
        ///表体自定义项4
        ///</summary>
        public string Define25 { get; set; }
        ///<summary>
        ///表体自定义项5
        ///</summary>
        public float Define26 { get; set; }
        ///<summary>
        ///表体自定义项6
        ///</summary>
        public float Define27 { get; set; }
        ///<summary>
        ///表体自定义项7
        ///</summary>
        public string Define28 { get; set; }
        ///<summary>
        ///表体自定义项8
        ///</summary>
        public string Define29 { get; set; }
        ///<summary>
        ///表体自定义项9
        ///</summary>
        public string Define30 { get; set; }
        ///<summary>
        ///表体自定义项10
        ///</summary>
        public string Define31 { get; set; }
        ///<summary>
        ///表体自定义项11
        ///</summary>
        public string Define32 { get; set; }
        ///<summary>
        ///表体自定义项12
        ///</summary>
        public string Define33 { get; set; }
        ///<summary>
        ///表体自定义项13
        ///</summary>
        public float Define34 { get; set; }
        ///<summary>
        ///表体自定义项14
        ///</summary>
        public float Define35 { get; set; }
        ///<summary>
        ///表体自定义项15
        ///</summary>
        public DateTime Define36 { get; set; }
        ///<summary>
        ///表体自定义项16
        ///</summary>
        public DateTime Define37 { get; set; }
        ///<summary>
        ///行号
        ///</summary>
        public float Rowno { get; set; }
        ///<summary>
        ///发货单号
        ///</summary>
        public string Subconsignmentcode { get; set; }
        ///<summary>
        ///订单号
        ///</summary>
        public string Ordercode { get; set; }

    }
}