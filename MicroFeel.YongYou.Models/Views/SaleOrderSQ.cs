using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.YongYou.Models.Models
{
    public class SaleOrderSQ
    {
        ///<summary>
        ///  销售定价自由项4  
        ///</summary>
        public bool? bsalepricefree4 { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal fstockquan { get; set; }
        ///<summary>
        ///  子件需求分类编码  
        ///</summary>
        public string cdetailsdemandcode { get; set; }
        ///<summary>
        ///  部门名称  
        ///</summary>
        public string cmdepname { get; set; }
        ///<summary>
        ///  产品预测单子表id  
        ///</summary>
        public int? forecastdid { get; set; }
        ///<summary>
        ///  客户订单专用  
        ///</summary>
        public bool? bspecialorder { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal fcanusequano { get; set; }
        ///<summary>
        ///  部门编码  
        ///</summary>
        public string cmdepcode { get; set; }
        ///<summary>
        ///  供应商名称  
        ///</summary>
        public string cvenname { get; set; }
        ///<summary>
        ///  累计下达委外量  
        ///</summary>
        public decimal fomquantity { get; set; }
        ///<summary>
        ///  预留总件数  
        ///</summary>
        public decimal? iprekeeptotnum { get; set; }
        ///<summary>
        ///  采购数量  
        ///</summary>
        public decimal? fpurquan { get; set; }
        ///<summary>
        ///  是否出库跟踪入库  
        ///</summary>
        public bool? bTrack { get; set; }
        ///<summary>
        ///  入库数量  
        ///</summary>
        public decimal finquantity { get; set; }
        ///<summary>
        ///  累计提前期  
        ///</summary>
        public int? iadvancedate { get; set; }
        ///<summary>
        ///  订单BOM是否完成  
        ///</summary>
        public string borderbomover { get; set; }
        ///<summary>
        ///  存货是否有自由项3  
        ///</summary>
        public bool? bfree3 { get; set; }
        ///<summary>
        ///  累计进口数量  
        ///</summary>
        public decimal fimquantity { get; set; }
        ///<summary>
        ///  存货是否有自由项8  
        ///</summary>
        public bool? bfree8 { get; set; }
        ///<summary>
        ///  需求分类代号  
        ///</summary>
        public string cdemandcode { get; set; }
        ///<summary>
        ///  退货数量  
        ///</summary>
        public decimal fretquantity { get; set; }
        ///<summary>
        ///  存货是否有自由项10  
        ///</summary>
        public bool? bfree10 { get; set; }
        ///<summary>
        ///  报价含税标识  
        ///</summary>
        public int? bsaleprice { get; set; }
        ///<summary>
        ///  客户最低售价  
        ///</summary>
        public decimal fcusminprice { get; set; }
        ///<summary>
        ///  预留件数  
        ///</summary>
        public decimal iprekeepnum { get; set; }
        ///<summary>
        ///  销售定价自由项6  
        ///</summary>
        public bool? bsalepricefree6 { get; set; }
        ///<summary>
        ///  单据行条码  
        ///</summary>
        public string cbsysbarcode { get; set; }
        ///<summary>
        ///  body_outid  
        ///</summary>
        public Guid body_outid { get; set; }
        ///<summary>
        ///  进口订单明细行  
        ///</summary>
        public long? iimid { get; set; }
        ///<summary>
        ///  关闭日期  
        ///</summary>
        public string dbclosedate { get; set; }
        ///<summary>
        ///  模型  
        ///</summary>
        public string binvmodel { get; set; }
        ///<summary>
        ///  销售定价自由项9  
        ///</summary>
        public bool? bsalepricefree9 { get; set; }
        ///<summary>
        ///  需求分类说明  
        ///</summary>
        public string cdemandmemo { get; set; }
        ///</summary
        ///<summary>
        ///  请购数量  >
        public decimal fappqty { get; set; }
        ///<summary>
        ///  累计收款本币  
        ///</summary>
        public decimal? imoneysum { get; set; }
        ///<summary>
        ///  销售定价自由项3  
        ///</summary>
        public bool? bsalepricefree3 { get; set; }
        ///<summary>
        ///  需求跟踪方式（1-销售订单行号；4-需求分类号5-销售订单号）  
        ///</summary>
        public int? idemandtype { get; set; }
        ///<summary>
        ///  来源单据行号  
        ///</summary>
        public int? icorrowno { get; set; }
        ///<summary>
        ///  供需政策  
        ///</summary>
        public string csrpolicy { get; set; }
        ///<summary>
        ///  来源单据类型  
        ///</summary>
        public string ccorvouchtype { get; set; }
        ///<summary>
        ///  子件需求分类名称  
        ///</summary>
        public string cdetailsdemandmemo { get; set; }
        ///<summary>
        ///  是否全部采购  
        ///</summary>
        public bool? ballpurchase { get; set; }
        ///<summary>
        ///  停用日期  
        ///</summary>
        public DateTime? dEDate { get; set; }
        ///<summary>
        ///  所属权限组  
        ///</summary>
        public int? iinvid { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string cchildcode { get; set; }
        ///<summary>
        ///  销售定价自由项10  
        ///</summary>
        public bool? bsalepricefree10 { get; set; }
        ///<summary>
        ///  销售定价自由项8  
        ///</summary>
        public bool? bsalepricefree8 { get; set; }
        ///<summary>
        ///  参考成本  
        ///</summary>
        public float iinvsprice { get; set; }
        ///<summary>
        ///  预留总数量  
        ///</summary>
        public decimal? iprekeeptotquantity { get; set; }
        ///<summary>
        ///  销售定价自由项2  
        ///</summary>
        public bool? bsalepricefree2 { get; set; }
        ///<summary>
        ///  销售定价自由项1  
        ///</summary>
        public bool? bsalepricefree1 { get; set; }
        ///<summary>
        ///  是否订单BOM  
        ///</summary>
        public string borderbom { get; set; }
        ///<summary>
        ///
        ///</summary>
        public short? icalctype { get; set; }
        ///<summary>
        ///  预订单autoid  
        ///</summary>
        public int? iaoids { get; set; }
        ///<summary>
        ///  存货是否有自由项6  
        ///</summary>
        public bool? bfree6 { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal fcanusequan { get; set; }
        ///<summary>
        ///  最新成本  
        ///</summary>
        public float iinvncost { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal fstockquano { get; set; }
        ///<summary>
        ///  供应商编码  
        ///</summary>
        public string cvencode { get; set; }
        ///<summary>
        ///  销售定价自由项7  
        ///</summary>
        public bool? bsalepricefree7 { get; set; }
        ///<summary>
        ///  允许生产订单  
        ///</summary>
        public bool? bproductbill { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string cparentcode { get; set; }
        ///<summary>
        ///  预订单号  
        ///</summary>
        public string cpreordercode { get; set; }
        ///<summary>
        ///  是否批次管理  
        ///</summary>
        public bool? bInvBatch { get; set; }
        ///<summary>
        ///  是否委外  
        ///</summary>
        public bool? bProxyForeign { get; set; }
        ///<summary>
        ///  供应商简称  
        ///</summary>
        public string cvenabbname { get; set; }
        ///<summary>
        ///  存货是否有自由项9  
        ///</summary>
        public bool? bfree9 { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal fchildrate { get; set; }
        ///<summary>
        ///  预留数量  
        ///</summary>
        public decimal? iprekeepquantity { get; set; }
        ///<summary>
        ///  PE跟单  
        ///</summary>
        public int? btracksalebill { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string cordercode { get; set; }
        ///<summary>
        ///  是否赠品  
        ///</summary>
        public int? bgift { get; set; }
        ///<summary>
        ///  销售定价自由项5  
        ///</summary>
        public bool? bsalepricefree5 { get; set; }
        ///<summary>
        ///  存货是否有自由项4  
        ///</summary>
        public bool? bfree4 { get; set; }
        ///<summary>
        ///  存货是否有自由项7  
        ///</summary>
        public bool? bfree7 { get; set; }
        ///<summary>
        ///  出库数量  
        ///</summary>
        public decimal foutquantity { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal fchildqty { get; set; }
        ///<summary>
        ///  使用客户BOM  
        ///</summary>
        public int? busecusbom { get; set; }
        ///<summary>
        ///  累计收款原币  
        ///</summary>
        public decimal? iexchsum { get; set; }
        ///<summary>
        ///  释放日期  
        ///</summary>
        public DateTime? dreleasedate { get; set; }
        ///<summary>
        ///  关闭时间  
        ///</summary>
        public DateTime? dbclosesystime { get; set; }
        ///<summary>
        ///  存货是否有自由项5  
        ///</summary>
        public bool? bfree5 { get; set; }
        ///<summary>
        ///  退货件数  
        ///</summary>
        public decimal fretnum { get; set; }
        ///<summary>
        ///  来源单据类型  
        ///</summary>
        public string ccorvouchtypename { get; set; }
        ///<summary>
        ///  销售订单子表标识  
        ///</summary>
        public int autoid { get; set; }
        ///<summary>
        ///  销售订单主表标识  
        ///</summary>
        public int? id { get; set; }
        ///<summary>
        ///  存货编码   
        ///</summary>
        public string cinvcode { get; set; }
        ///<summary>
        ///  是否应税劳务  
        ///</summary>
        public bool? bservice { get; set; }
        ///<summary>
        ///  存货名称  
        ///</summary>
        public string cinvname { get; set; }
        ///<summary>
        ///  存货代码  
        ///</summary>
        public string cinvaddcode { get; set; }
        ///<summary>
        ///  规格型号  
        ///</summary>
        public string cinvstd { get; set; }
        ///<summary>
        ///  计量单位编码  
        ///</summary>
        public string cunitid { get; set; }
        ///<summary>
        ///  主计量单位  
        ///</summary>
        public string cinvm_unit { get; set; }
        ///<summary>
        ///  计量单位组类别  
        ///</summary>
        public short? igrouptype { get; set; }
        ///<summary>
        ///  计量单位组编码  
        ///</summary>
        public string cgroupcode { get; set; }
        ///<summary>
        ///  辅计量单位  
        ///</summary>
        public string cinva_unit { get; set; }
        ///<summary>
        ///  存货自定义项1  
        ///</summary>
        public string cinvdefine1 { get; set; }
        ///<summary>
        ///  存货自定义项2  
        ///</summary>
        public string cinvdefine2 { get; set; }
        ///<summary>
        ///  存货自定义项3  
        ///</summary>
        public string cinvdefine3 { get; set; }
        ///<summary>
        ///  存货自定义项4  
        ///</summary>
        public string cinvdefine4 { get; set; }
        ///<summary>
        ///  存货自定义项5  
        ///</summary>
        public string cinvdefine5 { get; set; }
        ///<summary>
        ///  存货自定义项6  
        ///</summary>
        public string cinvdefine6 { get; set; }
        ///<summary>
        ///  存货自定义项7  
        ///</summary>
        public string cinvdefine7 { get; set; }
        ///<summary>
        ///  存货自定义项8  
        ///</summary>
        public string cinvdefine8 { get; set; }
        ///<summary>
        ///  存货自定义项9  
        ///</summary>
        public string cinvdefine9 { get; set; }
        ///<summary>
        ///  存货自定义项10  
        ///</summary>
        public string cinvdefine10 { get; set; }
        ///<summary>
        ///  存货自定义项11  
        ///</summary>
        public int? cinvdefine11 { get; set; }
        ///<summary>
        ///  存货自定义项12  
        ///</summary>
        public int? cinvdefine12 { get; set; }
        ///<summary>
        ///  存货自定义项13  
        ///</summary>
        public float cinvdefine13 { get; set; }
        ///<summary>
        ///  存货自定义项14  
        ///</summary>
        public float cinvdefine14 { get; set; }
        ///<summary>
        ///  存货自定义项15  
        ///</summary>
        public DateTime? cinvdefine15 { get; set; }
        ///<summary>
        ///  存货自定义项16  
        ///</summary>
        public DateTime? cinvdefine16 { get; set; }
        ///<summary>
        ///  数量  
        ///</summary>
        public decimal iquantity { get; set; }
        ///<summary>
        ///  辅计量数量  
        ///</summary>
        public decimal inum { get; set; }
        ///<summary>
        ///  报价  
        ///</summary>
        public decimal iquotedprice { get; set; }
        ///<summary>
        ///  原币无税单价  
        ///</summary>
        public decimal iunitprice { get; set; }
        ///<summary>
        ///  原币无税金额  
        ///</summary>
        public decimal? imoney { get; set; }
        ///<summary>
        ///  原币税额  
        ///</summary>
        public decimal? itax { get; set; }
        ///<summary>
        ///  原币价税合计  
        ///</summary>
        public decimal? isum { get; set; }
        ///<summary>
        ///  本币无税单价  
        ///</summary>
        public decimal inatunitprice { get; set; }
        ///<summary>
        ///  本币无税金额  
        ///</summary>
        public decimal? inatmoney { get; set; }
        ///<summary>
        ///  本币税额  
        ///</summary>
        public decimal? inattax { get; set; }
        ///<summary>
        ///  本币价税合计  
        ///</summary>
        public decimal? inatsum { get; set; }
        ///<summary>
        ///  本币折扣额  
        ///</summary>
        public decimal? inatdiscount { get; set; }
        ///<summary>
        ///  原币折扣额  
        ///</summary>
        public decimal? idiscount { get; set; }
        ///<summary>
        ///  累计发货数量  
        ///</summary>
        public decimal ifhquantity { get; set; }
        ///<summary>
        ///  累计发货辅计量数量  
        ///</summary>
        public decimal ifhnum { get; set; }
        ///<summary>
        ///  累计原币发货金额  
        ///</summary>
        public decimal? ifhmoney { get; set; }
        ///<summary>
        ///  累计开票数量  
        ///</summary>
        public decimal ikpquantity { get; set; }
        ///<summary>
        ///  零售单价  
        ///</summary>
        public decimal fsalecost { get; set; }
        ///<summary>
        ///  零售金额  
        ///</summary>
        public decimal fsaleprice { get; set; }
        ///<summary>
        ///  累计开票辅计量数量  
        ///</summary>
        public decimal ikpnum { get; set; }
        ///<summary>
        ///  累计原币开票金额  
        ///</summary>
        public decimal? ikpmoney { get; set; }
        ///<summary>
        ///  预发货日期  
        ///</summary>
        public DateTime? dpredate { get; set; }
        ///<summary>
        ///  备注  
        ///</summary>
        public string cmemo { get; set; }
        ///<summary>
        ///  存货自由项1  
        ///</summary>
        public string cfree1 { get; set; }
        ///<summary>
        ///  存货自由项2  
        ///</summary>
        public string cfree2 { get; set; }
        ///<summary>
        ///  换算率  
        ///</summary>
        public decimal? iinvexchrate { get; set; }
        ///<summary>
        ///  最低售价  
        ///</summary>
        public float iinvlscost { get; set; }
        ///<summary>
        ///  原币含税单价  
        ///</summary>
        public decimal itaxunitprice { get; set; }
        ///<summary>
        ///  存货是否有自由项1  
        ///</summary>
        public bool? bfree1 { get; set; }
        ///<summary>
        ///  存货是否有自由项2  
        ///</summary>
        public bool? bfree2 { get; set; }
        ///<summary>
        ///  是否折扣  
        ///</summary>
        public bool? binvtype { get; set; }
        ///<summary>
        ///  税率  
        ///</summary>
        public decimal itaxrate { get; set; }
        ///<summary>
        ///  扣率  
        ///</summary>
        public decimal kl { get; set; }
        ///<summary>
        ///  二次扣率  
        ///</summary>
        public decimal kl2 { get; set; }
        ///<summary>
        ///  表体自定义项22  
        ///</summary>
        public string cdefine22 { get; set; }
        ///<summary>
        ///  表体自定义项23  
        ///</summary>
        public string cdefine23 { get; set; }
        ///<summary>
        ///  表体自定义项24  
        ///</summary>
        public string cdefine24 { get; set; }
        ///<summary>
        ///  表体自定义项25  
        ///</summary>
        public string cdefine25 { get; set; }
        ///<summary>
        ///  表体自定义项26  
        ///</summary>
        public float cdefine26 { get; set; }
        ///<summary>
        ///  表体自定义项27  
        ///</summary>
        public float cdefine27 { get; set; }
        ///<summary>
        ///  表体自定义项28  
        ///</summary>
        public string cdefine28 { get; set; }
        ///<summary>
        ///  表体自定义项29  
        ///</summary>
        public string cdefine29 { get; set; }
        ///<summary>
        ///  表体自定义项30  
        ///</summary>
        public string cdefine30 { get; set; }
        ///<summary>
        ///  表体自定义项31  
        ///</summary>
        public string cdefine31 { get; set; }
        ///<summary>
        ///  表体自定义项32  
        ///</summary>
        public string cdefine32 { get; set; }
        ///<summary>
        ///  表体自定义项33  
        ///</summary>
        public string cdefine33 { get; set; }
        ///<summary>
        ///  表体自定义项34  
        ///</summary>
        public int? cdefine34 { get; set; }
        ///<summary>
        ///  表体自定义项35  
        ///</summary>
        public int? cdefine35 { get; set; }
        ///<summary>
        ///  表体自定义项36  
        ///</summary>
        public DateTime? cdefine36 { get; set; }
        ///<summary>
        ///  表体自定义项37  
        ///</summary>
        public DateTime? cdefine37 { get; set; }
        ///<summary>
        ///  销售订单子表标识2  
        ///</summary>
        public int? isosid { get; set; }
        ///<summary>
        ///  项目编码  
        ///</summary>
        public string citemcode { get; set; }
        ///<summary>
        ///  项目大类编码  
        ///</summary>
        public string citem_class { get; set; }
        ///<summary>
        ///  倒扣1  
        ///</summary>
        public decimal dkl1 { get; set; }
        ///<summary>
        ///  倒扣2  
        ///</summary>
        public decimal dkl2 { get; set; }
        ///<summary>
        ///  项目名称  
        ///</summary>
        public string citemname { get; set; }
        ///<summary>
        ///  项目大类名称  
        ///</summary>
        public string citem_cname { get; set; }
        ///<summary>
        ///  存货自由项3  
        ///</summary>
        public string cfree3 { get; set; }
        ///<summary>
        ///  存货自由项4  
        ///</summary>
        public string cfree4 { get; set; }
        ///<summary>
        ///  存货自由项5  
        ///</summary>
        public string cfree5 { get; set; }
        ///<summary>
        ///  存货自由项6  
        ///</summary>
        public string cfree6 { get; set; }
        ///<summary>
        ///  存货自由项7  
        ///</summary>
        public string cfree7 { get; set; }
        ///<summary>
        ///  存货自由项8  
        ///</summary>
        public string cfree8 { get; set; }
        ///<summary>
        ///  存货自由项9  
        ///</summary>
        public string cfree9 { get; set; }
        ///<summary>
        ///  存货自由项10  
        ///</summary>
        public string cfree10 { get; set; }
        ///<summary>
        ///  存货所属权限组  
        ///</summary>
        public int? cinvauthid { get; set; }
        ///<summary>
        ///  行关闭人  
        ///</summary>
        public string cscloser { get; set; }
        ///<summary>
        ///  行号  
        ///</summary>
        public int? irowno { get; set; }
        ///<summary>
        ///  累计下达生产量  
        ///</summary>
        public decimal? imoquantity { get; set; }
        ///<summary>
        ///  客户BOMID  
        ///</summary>
        public int? icusbomid { get; set; }
        ///<summary>
        ///  选配标志  
        ///</summary>
        public string cconfigstatus { get; set; }
        ///<summary>
        ///  计量单位编码  
        ///</summary>
        public string ccomunitcode { get; set; }
        ///<summary>
        ///  PTO母件顺序号  
        ///</summary>
        public int? ippartseqid { get; set; }
        ///<summary>
        ///  母件物料id  
        ///</summary>
        public int? ippartid { get; set; }
        ///<summary>
        ///  母件数量  
        ///</summary>
        public decimal? ippartqty { get; set; }
        ///<summary>
        ///  预完工日期  
        ///</summary>
        public DateTime? dpremodate { get; set; }
        ///<summary>
        ///  报价单id  
        ///</summary>
        public int? iquoid { get; set; }
        ///<summary>
        ///  报价单号  
        ///</summary>
        public string cquocode { get; set; }
        ///<summary>
        ///  对应条形码编码  
        ///</summary>
        public string cbarcode { get; set; }
        ///<summary>
        ///  合同号  
        ///</summary>
        public string ccontractid { get; set; }
        ///<summary>
        ///  合同标的  
        ///</summary>
        public string ccontracttagcode { get; set; }
        ///<summary>
        ///  合同cGuid  
        ///</summary>
        public Guid ccontractrowguid { get; set; }
        ///<summary>
        ///  是否ATO模型  
        ///</summary>
        public string batomodel { get; set; }
        ///<summary>
        ///  是否PTO模型  
        ///</summary>
        public string bptomodel { get; set; }
        ///<summary>
        ///  客户存货编码  
        ///</summary>
        public string ccusinvcode { get; set; }
        ///<summary>
        ///  客户存货名称  
        ///</summary>
        public string ccusinvname { get; set; }

    }
}
