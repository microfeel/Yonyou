using System;using System.Collections.Generic;using System.Text.Json.Serialization;namespace MicroFeel.Yonyou.Api{	public class Department	{		///<Summary>		///部门编码		///</Summary>		[JsonPropertyName("code")]		public string Code { get;set; }		///<Summary>		///部门名称		///</Summary>		[JsonPropertyName("name")]		public string Name { get;set; }		///<Summary>		///是否末级		///</Summary>		[JsonPropertyName("endflag")]		public string Endflag { get;set; }		///<Summary>		///编码级次		///</Summary>		[JsonPropertyName("rank")]		public string Rank { get;set; }		///<Summary>		///负责人编码		///</Summary>		[JsonPropertyName("manager")]		public string Manager { get;set; }		///<Summary>		///负责人名称		///</Summary>		[JsonPropertyName("managername")]		public string Managername { get;set; }		///<Summary>		///分管领导编码		///</Summary>		[JsonPropertyName("cdepleader")]		public string Cdepleader { get;set; }		///<Summary>		///分管领导名称		///</Summary>		[JsonPropertyName("cdepleadername")]		public string Cdepleadername { get;set; }		///<Summary>		///备注		///</Summary>		[JsonPropertyName("remark")]		public string Remark { get;set; }		///<Summary>		///时间戳		///</Summary>		[JsonPropertyName("timestamp")]		public string Timestamp { get;set; }		///<Summary>		///撤销日期		///</Summary>		[JsonPropertyName("ddependdate")]		public DateTime Ddependdate { get;set; }	}}