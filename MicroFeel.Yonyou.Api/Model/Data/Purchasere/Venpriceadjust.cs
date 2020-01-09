using System;using System.Collections.Generic;using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class Venpriceadjust
    {
        ///<Summary>
        ///调价日期(默认当天）
        ///</Summary>
        [JsonPropertyName("ddate")]
        public DateTime Ddate { get; set; }
        ///<Summary>
        ///单据编号
        ///</Summary>
        [JsonPropertyName("ccode")]
        public string Ccode { get; set; }
        ///<Summary>
        ///调价业务员编码
        ///</Summary>
        [JsonPropertyName("cpersoncode")]
        public string Cpersoncode { get; set; }
        ///<Summary>
        ///调价业务员
        ///</Summary>
        [JsonPropertyName("cpersonname")]
        public string Cpersonname { get; set; }
        ///<Summary>
        ///调价部门编码
        ///</Summary>
        [JsonPropertyName("deptcode")]
        public string Deptcode { get; set; }
        ///<Summary>
        ///调价部门
        ///</Summary>
        [JsonPropertyName("cdepname")]
        public string Cdepname { get; set; }
        ///<Summary>
        ///表头自定义项1
        ///</Summary>
        [JsonPropertyName("define1")]
        public string Define1 { get; set; }
        ///<Summary>
        ///表头自定义项2
        ///</Summary>
        [JsonPropertyName("define2")]
        public string Define2 { get; set; }
        ///<Summary>
        ///表头自定义项3
        ///</Summary>
        [JsonPropertyName("define3")]
        public string Define3 { get; set; }
        ///<Summary>
        ///表头自定义项4
        ///</Summary>
        [JsonPropertyName("define4")]
        public string Define4 { get; set; }
        ///<Summary>
        ///表头自定义项5
        ///</Summary>
        [JsonPropertyName("define5")]
        public string Define5 { get; set; }
        ///<Summary>
        ///表头自定义项6
        ///</Summary>
        [JsonPropertyName("define6")]
        public string Define6 { get; set; }
        ///<Summary>
        ///表头自定义项7
        ///</Summary>
        [JsonPropertyName("define7")]
        public string Define7 { get; set; }
        ///<Summary>
        ///表头自定义项8
        ///</Summary>
        [JsonPropertyName("define8")]
        public string Define8 { get; set; }
        ///<Summary>
        ///表头自定义项9
        ///</Summary>
        [JsonPropertyName("define9")]
        public string Define9 { get; set; }
        ///<Summary>
        ///表头自定义项10
        ///</Summary>
        [JsonPropertyName("define10")]
        public string Define10 { get; set; }
        ///<Summary>
        ///表头自定义项11
        ///</Summary>
        [JsonPropertyName("define11")]
        public string Define11 { get; set; }
        ///<Summary>
        ///表头自定义项12
        ///</Summary>
        [JsonPropertyName("define12")]
        public string Define12 { get; set; }
        ///<Summary>
        ///表头自定义项13
        ///</Summary>
        [JsonPropertyName("define13")]
        public string Define13 { get; set; }
        ///<Summary>
        ///表头自定义项14
        ///</Summary>
        [JsonPropertyName("define14")]
        public string Define14 { get; set; }
        ///<Summary>
        ///表头自定义项15
        ///</Summary>
        [JsonPropertyName("define15")]
        public string Define15 { get; set; }
        ///<Summary>
        ///表头自定义项16
        ///</Summary>
        [JsonPropertyName("define16")]
        public string Define16 { get; set; }
        ///<Summary>
        ///供应类型(1=采购;2=委外;3=生产;4=进口)，默认值：1
        ///</Summary>
        [JsonPropertyName("isupplytype")]
        public float Isupplytype { get; set; }
        ///<Summary>
        ///表头备注
        ///</Summary>
        [JsonPropertyName("memo")]
        public string Memo { get; set; }
        ///<Summary>
        ///是否含税价（0=不含税;1=含税），默认值：1
        ///</Summary>
        [JsonPropertyName("btaxcost")]
        public bool Btaxcost { get; set; }
        ///<Summary>
        ///制单人
        ///</Summary>
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        ///<Summary>
        ///供货单位编号
        ///</Summary>
        [JsonPropertyName("entry")]
        public IList<VenpriceadjustEntry> Venpriceadjustentry { get; set; }
    }

    public class VenpriceadjustEntry
    {

        ///<Summary>
        ///供货单位编号
        ///</Summary>
        [JsonPropertyName("cvencode")]
        public string Cvencode { get; set; }

        ///<Summary>
        ///供货单位
        ///</Summary>
        [JsonPropertyName("cvenabbname")]
        public string Cvenabbname { get; set; }

        ///<Summary>
        ///供应商全称
        ///</Summary>
        [JsonPropertyName("cvenname")]
        public string Cvenname { get; set; }

        ///<Summary>
        ///存货编码
        ///</Summary>
        [JsonPropertyName("cinvcode")]
        public string Cinvcode { get; set; }

        ///<Summary>
        ///存货代码
        ///</Summary>
        [JsonPropertyName("cinvaddcode")]
        public string Cinvaddcode { get; set; }

        ///<Summary>
        ///存货名称
        ///</Summary>
        [JsonPropertyName("cinvname")]
        public string Cinvname { get; set; }

        ///<Summary>
        ///规格型号
        ///</Summary>
        [JsonPropertyName("cinvstd")]
        public string Cinvstd { get; set; }

        ///<Summary>
        ///生效日期 yyyy-MM-dd （默认当天）
        ///</Summary>
        [JsonPropertyName("dstartdate")]
        public DateTime Dstartdate { get; set; }

        ///<Summary>
        ///失效日期 yyyy-MM-dd
        ///</Summary>
        [JsonPropertyName("denddate")]
        public DateTime Denddate { get; set; }

        ///<Summary>
        ///币种（默认：人民币）
        ///</Summary>
        [JsonPropertyName("cexch_name")]
        public string CexchName { get; set; }

        ///<Summary>
        ///贸易术语代码
        ///</Summary>
        [JsonPropertyName("ctermcode")]
        public string Ctermcode { get; set; }

        ///<Summary>
        ///贸易术语
        ///</Summary>
        [JsonPropertyName("ctermname")]
        public string Ctermname { get; set; }

        ///<Summary>
        ///是否促销价（0=否;1=是），默认值：0
        ///</Summary>
        [JsonPropertyName("bsales")]
        public bool Bsales { get; set; }

        ///<Summary>
        ///表体备注
        ///</Summary>
        [JsonPropertyName("cbodymemo")]
        public string Cbodymemo { get; set; }

        ///<Summary>
        ///自由项1
        ///</Summary>
        [JsonPropertyName("cfree1")]
        public string Cfree1 { get; set; }

        ///<Summary>
        ///自由项2
        ///</Summary>
        [JsonPropertyName("cfree2")]
        public string Cfree2 { get; set; }

        ///<Summary>
        ///自由项3
        ///</Summary>
        [JsonPropertyName("cfree3")]
        public string Cfree3 { get; set; }

        ///<Summary>
        ///自由项4
        ///</Summary>
        [JsonPropertyName("cfree4")]
        public string Cfree4 { get; set; }

        ///<Summary>
        ///自由项5
        ///</Summary>
        [JsonPropertyName("cfree5")]
        public string Cfree5 { get; set; }

        ///<Summary>
        ///自由项6
        ///</Summary>
        [JsonPropertyName("cfree6")]
        public string Cfree6 { get; set; }

        ///<Summary>
        ///自由项7
        ///</Summary>
        [JsonPropertyName("cfree7")]
        public string Cfree7 { get; set; }

        ///<Summary>
        ///自由项8
        ///</Summary>
        [JsonPropertyName("cfree8")]
        public string Cfree8 { get; set; }

        ///<Summary>
        ///自由项9
        ///</Summary>
        [JsonPropertyName("cfree9")]
        public string Cfree9 { get; set; }

        ///<Summary>
        ///自由项10
        ///</Summary>
        [JsonPropertyName("cfree10")]
        public string Cfree10 { get; set; }

        ///<Summary>
        ///表体自定义项1
        ///</Summary>
        [JsonPropertyName("cdefine22")]
        public string Cdefine22 { get; set; }

        ///<Summary>
        ///表体自定义项2
        ///</Summary>
        [JsonPropertyName("cdefine23")]
        public string Cdefine23 { get; set; }

        ///<Summary>
        ///表体自定义项3
        ///</Summary>
        [JsonPropertyName("cdefine24")]
        public string Cdefine24 { get; set; }

        ///<Summary>
        ///表体自定义项4
        ///</Summary>
        [JsonPropertyName("cdefine25")]
        public string Cdefine25 { get; set; }

        ///<Summary>
        ///表体自定义项5
        ///</Summary>
        [JsonPropertyName("cdefine26")]
        public string Cdefine26 { get; set; }

        ///<Summary>
        ///表体自定义项6
        ///</Summary>
        [JsonPropertyName("cdefine27")]
        public string Cdefine27 { get; set; }

        ///<Summary>
        ///表体自定义项7
        ///</Summary>
        [JsonPropertyName("cdefine28")]
        public string Cdefine28 { get; set; }

        ///<Summary>
        ///表体自定义项8
        ///</Summary>
        [JsonPropertyName("cdefine29")]
        public string Cdefine29 { get; set; }

        ///<Summary>
        ///表体自定义项9
        ///</Summary>
        [JsonPropertyName("cdefine30")]
        public string Cdefine30 { get; set; }

        ///<Summary>
        ///表体自定义项10
        ///</Summary>
        [JsonPropertyName("cdefine31")]
        public string Cdefine31 { get; set; }

        ///<Summary>
        ///表体自定义项11
        ///</Summary>
        [JsonPropertyName("cdefine32")]
        public string Cdefine32 { get; set; }

        ///<Summary>
        ///表体自定义项12
        ///</Summary>
        [JsonPropertyName("cdefine33")]
        public string Cdefine33 { get; set; }

        ///<Summary>
        ///表体自定义项13
        ///</Summary>
        [JsonPropertyName("cdefine34")]
        public string Cdefine34 { get; set; }

        ///<Summary>
        ///表体自定义项14
        ///</Summary>
        [JsonPropertyName("cdefine35")]
        public string Cdefine35 { get; set; }

        ///<Summary>
        ///表体自定义项15
        ///</Summary>
        [JsonPropertyName("cdefine36")]
        public string Cdefine36 { get; set; }

        ///<Summary>
        ///表体自定义项16
        ///</Summary>
        [JsonPropertyName("cdefine37")]
        public string Cdefine37 { get; set; }

        ///<Summary>
        ///数量下限
        ///</Summary>
        [JsonPropertyName("fminquantity")]
        public float Fminquantity { get; set; }

        ///<Summary>
        ///原币单价
        ///</Summary>
        [JsonPropertyName("iunitprice")]
        public float Iunitprice { get; set; }

        ///<Summary>
        ///税率（默认：17）
        ///</Summary>
        [JsonPropertyName("itaxrate")]
        public float Itaxrate { get; set; }

        ///<Summary>
        ///含税单价
        ///</Summary>
        [JsonPropertyName("itaxunitprice")]
        public float Itaxunitprice { get; set; }

        ///<Summary>
        ///行号
        ///</Summary>
        [JsonPropertyName("ivouchrowno")]
        public float Ivouchrowno { get; set; }

    }

}