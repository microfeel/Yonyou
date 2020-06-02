using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{ 
    public class Bom
    {
         ///<Summary>
        ///主键ID
        ///</Summary>
        [JsonPropertyName("bomid")]
        public string Bomid { get; set; }
        ///<Summary>
        ///BOM类型(主要/替代)
        ///</Summary>
        [JsonPropertyName("bomtype")]
        public string Bomtype { get; set; }
        ///<Summary>
        ///版本号 
        ///</Summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
        ///<Summary>
        ///版本说明 
        ///</Summary>
        [JsonPropertyName("versiondesc")]
        public string Versiondesc { get; set; }
        ///<Summary>
        ///版本生效日 
        ///</Summary>
        [JsonPropertyName("versioneffdate")]
        public DateTime Versioneffdate { get; set; }
        ///<Summary>
        ///版本失效日 
        ///</Summary>
        [JsonPropertyName("versionenddate")]
        public DateTime Versionenddate { get; set; }
        ///<Summary>
        ///替代标识 
        ///</Summary>
        [JsonPropertyName("identcode")]
        public string Identcode { get; set; }
        ///<Summary>
        ///替代说明 
        ///</Summary>
        [JsonPropertyName("identdesc")]
        public string Identdesc { get; set; }
        ///<Summary>
        ///母件物料Id
        ///</Summary>
        [JsonPropertyName("parentid")]
        public string Parentid { get; set; }
        ///<Summary>
        ///存货编码 
        ///</Summary>
        [JsonPropertyName("cinvcode")]
        public string Cinvcode { get; set; }
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
        ///存货大类编码
        ///</Summary>
        [JsonPropertyName("cinvccode")]
        public string Cinvccode { get; set; }
        ///<Summary>
        ///存货名称
        ///</Summary>
        [JsonPropertyName("cinvcname")]
        public string Cinvcname { get; set; }
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
        ///母件损耗率
        ///</Summary>
        [JsonPropertyName("parentscrap")]
        public string Parentscrap { get; set; }
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
        public DateTime Define4 { get; set; }
        ///<Summary>
        ///表头自定义项5
        ///</Summary>
        [JsonPropertyName("define5")]
        public string Define5 { get; set; }
        ///<Summary>
        ///表头自定义项6
        ///</Summary>
        [JsonPropertyName("define6")]
        public DateTime Define6 { get; set; }
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
        ///状态(1:新建/3:审核/4:停用)
        ///</Summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
        ///<Summary>
        ///创建人
        ///</Summary>
        [JsonPropertyName("createuser")]
        public string Createuser { get; set; }
        ///<Summary>
        ///创建日期
        ///</Summary>
        [JsonPropertyName("createdate")]
        public DateTime Createdate { get; set; }
        ///<Summary>
        ///关闭人
        ///</Summary>
        [JsonPropertyName("closeuser")]
        public string Closeuser { get; set; }
        ///<Summary>
        ///关闭日期
        ///</Summary>
        [JsonPropertyName("closedate")]
        public DateTime Closedate { get; set; }
        ///<Summary>
        ///子件ID
        ///</Summary>
        [JsonPropertyName("entry")]
        public IList<BomEntry> Bomentry { get; set; }
    }

    public class BomEntry
    {

        ///<Summary>
        ///子件ID
        ///</Summary>
        [JsonPropertyName("opcomponentid")]
        public string Opcomponentid { get; set; }


        ///<Summary>
        ///序号
        ///</Summary>
        [JsonPropertyName("sortseq")]
        public string Sortseq { get; set; }

        ///<Summary>
        ///工序代号
        ///</Summary>
        [JsonPropertyName("opseq")]
        public string Opseq { get; set; }

        ///<Summary>
        ///子件物料Id
        ///</Summary>
        [JsonPropertyName("componentid")]
        public string Componentid { get; set; }

        ///<Summary>
        ///子件生效日
        ///</Summary>
        [JsonPropertyName("effbegdate")]
        public DateTime Effbegdate { get; set; }

        ///<Summary>
        ///子件失效日
        ///</Summary>
        [JsonPropertyName("effenddate")]
        public DateTime Effenddate { get; set; }

        ///<Summary>
        ///固定/变动批量(0/1)
        ///</Summary>
        [JsonPropertyName("fvflag")]
        public string Fvflag { get; set; }

        ///<Summary>
        ///基本用量-分子
        ///</Summary>
        [JsonPropertyName("baseqtyn")]
        public string Baseqtyn { get; set; }

        ///<Summary>
        ///基本用量-分母
        ///</Summary>
        [JsonPropertyName("baseqtyd")]
        public string Baseqtyd { get; set; }

        ///<Summary>
        ///子件损耗率
        ///</Summary>
        [JsonPropertyName("compscrap")]
        public string Compscrap { get; set; }

        ///<Summary>
        ///是否联副产品
        ///</Summary>
        [JsonPropertyName("byproductflag")]
        public string Byproductflag { get; set; }

        ///<Summary>
        ///辅助计量单位
        ///</Summary>
        [JsonPropertyName("auxunitcode")]
        public string Auxunitcode { get; set; }

        ///<Summary>
        ///换算率
        ///</Summary>
        [JsonPropertyName("changerate")]
        public string Changerate { get; set; }

        ///<Summary>
        ///辅助基本用量
        ///</Summary>
        [JsonPropertyName("auxbaseqtyn")]
        public string Auxbaseqtyn { get; set; }

        ///<Summary>
        ///产出类型(1:空/2:联产品/3:副产品)
        ///</Summary>
        [JsonPropertyName("producttype")]
        public string Producttype { get; set; }

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
        public DateTime Define36 { get; set; }

        ///<Summary>
        ///表体自定义项16
        ///</Summary>
        [JsonPropertyName("define37")]
        public DateTime Define37 { get; set; }

        ///<Summary>
        ///备注
        ///</Summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        ///<Summary>
        ///是否循环
        ///</Summary>
        [JsonPropertyName("recursiveflag")]
        public string Recursiveflag { get; set; }
        ///<Summary>
        ///偏置期
        ///</Summary>
        [JsonPropertyName("offset")]
        public string Offset { get; set; }

        ///<Summary>
        ///WIP属性(1入库/2工序/3领料/4虚拟)
        ///</Summary>
        [JsonPropertyName("wiptype")]
        public string Wiptype { get; set; }

        ///<Summary>
        ///是/否累计成本（1/0）
        ///</Summary>
        [JsonPropertyName("accucostflag")]
        public string Accucostflag { get; set; }

        ///<Summary>
        ///领料部门
        ///</Summary>
        [JsonPropertyName("drawdeptcode")]
        public string Drawdeptcode { get; set; }

        ///<Summary>
        ///部门
        ///</Summary>
        [JsonPropertyName("cdepname")]
        public string Cdepname { get; set; }

        ///<Summary>
        ///仓库代号
        ///</Summary>
        [JsonPropertyName("whcode")]
        public string Whcode { get; set; }

        ///<Summary>
        ///仓库
        ///</Summary>
        [JsonPropertyName("cwhname")]
        public string Cwhname { get; set; }

        ///<Summary>
        ///是否可选(1/0) 
        ///</Summary>
        [JsonPropertyName("optionalflag")]
        public string Optionalflag { get; set; }

        ///<Summary>
        ///互斥原则(1-ONE/2-ALL/3-ANY/4-AL0) 
        ///</Summary>
        [JsonPropertyName("mutexrule")]
        public string Mutexrule { get; set; }

        ///<Summary>
        ///计划比例 
        ///</Summary>
        [JsonPropertyName("planfactor")]
        public string Planfactor { get; set; }

        ///<Summary>
        ///成本投产推算
        ///</Summary>
        [JsonPropertyName("costwiprel")]
        public string Costwiprel { get; set; }

        ///<Summary>
        ///替代标识
        ///</Summary>
        [JsonPropertyName("dsubflag")]
        public string Dsubflag { get; set; }

    }
} 