using System;using System.Collections.Generic;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{	public class Define	{		///<Summary>		///自定义项大类名称		///</Summary>		[JsonPropertyName("class")]		public string Class { get;set; }		///<Summary>		///自定义项名称		///</Summary>		[JsonPropertyName("item")]		public string Item { get;set; }		///<Summary>		///序号		///</Summary>		[JsonPropertyName("id")]		public string Id { get;set; }		///<Summary>		///自定义项或自由项值		///</Summary>		[JsonPropertyName("value")]		public string Value { get;set; }		///<Summary>		///代码		///</Summary>		[JsonPropertyName("alias")]		public string Alias { get;set; }		///<Summary>		///自由项对应条码中的编码		///</Summary>		[JsonPropertyName("barcode")]		public string Barcode { get;set; }	}}