using System;using System.Collections.Generic;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{	public class Dutytype
	{ 		///<Summary>		///代码		///</Summary>		[JsonPropertyName("code")]		public string Code { get;set; }		///<Summary>		///代码名称		///</Summary>		[JsonPropertyName("name")]		public string Name { get;set; }		///<Summary>		///简称		///</Summary>		[JsonPropertyName("simplename")]		public string Simplename { get;set; }		///<Summary>		///简拼		///</Summary>		[JsonPropertyName("simplespell")]		public string Simplespell { get;set; }		///<Summary>		///代码级别		///</Summary>		[JsonPropertyName("levels")]		public float Levels { get;set; }		///<Summary>		///上级代码		///</Summary>		[JsonPropertyName("pcodeid")]		public string Pcodeid { get;set; }		///<Summary>		///系统/自定义标志		///</Summary>		[JsonPropertyName("sysflag")]		public string Sysflag { get;set; }		///<Summary>		///是否有下级代码		///</Summary>		[JsonPropertyName("childflag")]		public string Childflag { get;set; }		///<Summary>		///显示/隐藏		///</Summary>		[JsonPropertyName("hideflag")]		public string Hideflag { get;set; }		///<Summary>		///备注		///</Summary>		[JsonPropertyName("memo")]		public string Memo { get;set; }	}}