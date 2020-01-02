using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Data
{
    public class Person
    {///<summary>
     ///人员编码
     ///</summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        ///<summary>
        ///操作员编码
        ///</summary>
        [JsonPropertyName("cuser_id")]
        public string Cuser_id { get; set; }
        ///<summary>
        ///操作员名称
        ///</summary>
        [JsonPropertyName("cuser_name")]
        public string Cuser_name { get; set; }
        ///<summary>
        ///人员名称
        ///</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        ///<summary>
        ///部门编码
        ///</summary>
        [JsonPropertyName("cdept_num")]
        public string Cdept_num { get; set; }
        ///<summary>
        ///部门名称
        ///</summary>
        [JsonPropertyName("cdept_name")]
        public string Cdept_name { get; set; }
        ///<summary>
        ///人员属性
        ///</summary>
        [JsonPropertyName("cpsnproperty")]
        public string Cpsnproperty { get; set; }
        ///<summary>
        ///人员性别（1:男 2:女）
        ///</summary>
        [JsonPropertyName("rsex")]
        public string Rsex { get; set; }
        ///<summary>
        ///人员手机号
        ///</summary>
        [JsonPropertyName("cpsnmobilephone")]
        public string Cpsnmobilephone { get; set; }
        ///<summary>
        ///人员邮箱
        ///</summary>
        [JsonPropertyName("cpsnemail")]
        public string Cpsnemail { get; set; }
        ///<summary>
        ///职位编码
        ///</summary>
        [JsonPropertyName("cjobcode")]
        public string Cjobcode { get; set; }
        ///<summary>
        ///职位名称
        ///</summary>
        [JsonPropertyName("vjobname")]
        public string Vjobname { get; set; }
        ///<summary>
        ///通讯地址
        ///</summary>
        [JsonPropertyName("cpsnpostaddr")]
        public string Cpsnpostaddr { get; set; }
        ///<summary>
        ///人员类型
        ///</summary>
        [JsonPropertyName("rpersontype")]
        public string Rpersontype { get; set; }
        ///<summary>
        ///人员类型名称
        ///</summary>
        [JsonPropertyName("rpersontypename")]
        public string Rpersontypename { get; set; }

        ///<summary>
        ///证件类型（0：身份证 1：护照 2：军人证 3：港澳身份证 4：台胞证 9：其他）
        ///</summary>
        [JsonPropertyName("rIDType")]
        public string RIDType { get; set; }
        ///<summary>
        ///雇佣状态（0：在职 20：离退 30：离职）1
        ///</summary>
        [JsonPropertyName("rEmployState")]
        public string REmployState { get; set; }
        ///<summary>
        ///QQ号
        ///</summary>
        [JsonPropertyName("cpsnqqcode")]
        public string Cpsnqqcode { get; set; }
        ///<summary>
        ///证件号码
        ///</summary>
        [JsonPropertyName("vIDNo")]
        public string VIDNo { get; set; }
        ///<summary>
        ///0=非业务员；1=业务员
        ///</summary>
        [JsonPropertyName("bpsnperson")]
        public string Bpsnperson { get; set; }
        ///<summary>
        ///时间戳
        ///</summary>
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }

        [JsonPropertyName("openbank")]
        public OpenBank OpenBank { get; set; }

    }

    public class OpenBank
    {
        [JsonPropertyName("bankaccount")]
        public string Bankaccount { get; set; }
        [JsonPropertyName("bankname")] 
        public string Bankname { get; set; }
        [JsonPropertyName("defaultaccount")] 
        public string Defaultaccount { get; set; }
        [JsonPropertyName("cbankname")]
        public string Cbankname { get; set; }
        [JsonPropertyName("caname")]
        public string Caname { get; set; }
    }
}
