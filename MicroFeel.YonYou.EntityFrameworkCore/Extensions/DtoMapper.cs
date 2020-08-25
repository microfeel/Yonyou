using MicroFeel.Finance.Models;
using MicroFeel.Finance.Models.DbDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Extensions
{
    public static class DtoMapper
    {
        public static DtoCustomer ToDtoCustomer(this Data.Customer customer)
        {
            return new DtoCustomer()
            {
                Address = customer.CCusAddress,
                City = customer.CCity,
                Province = customer.CProvince,
                Code = customer.CCusCode,
                Name = customer.CCusName
            };
        }
        public static DtoProductClass ToDtoProductClass(this Data.InventoryClass inventoryClass)
        {
            return new DtoProductClass()
            {
                ClassCode = inventoryClass.CInvCcode,
                ClassName = inventoryClass.CInvCname,
                IsLeaf = inventoryClass.BInvCend.Value,
                Level = inventoryClass.IInvCgrade
            };
        }
        public static DtoPerson ToDtoPerson(this Data.Person person)
        {
            return new DtoPerson()
            {
                Code = person.CPersonCode,
                DeparmentCode = person.CDepCode,
                Name = person.CPersonName,
                PhoneCode = person.CPersonPhone
            };
        }
        public static DtoSupplier GetDtoSupplier(this Data.Vendor vendor)
        {
            return new DtoSupplier()
            {
                Code = vendor.CVenCode,
                Name = vendor.CVenName,
                PhoneCode = vendor.CVenPhone
            };
        }
        public static DtoOutsourcingOrder GetDtoOutsourcingOrder(this Data.OmModetails t)
        {
            return new DtoOutsourcingOrder()
            {
                DateTime = t.OrderDate,
                DetailId = t.ModetailsId,
                OrderNo = t.OrderNo,
                CommitDate = t.DArriveDate,
                ProductName = t.ProductName,
                ProductModel = t.ProductModel,
                ProductNumbers = t.ProductNumbers,
                Numbers = t.IQuantity// - (t.IReceivedQty ?? t.IArrQty ?? t.Freceivedqty)
            };
        }
        public static DtoMaterialOrder GetDtoMaterialOrder(this Data.Materialappm materialappm)
        {
            return new DtoMaterialOrder()
            {
                Maker = materialappm.Cmaker,
                Id = materialappm.Id,
                OrderNo = materialappm.Ccode,
                Remark = materialappm.Cmemo,
                CreateDate = materialappm.Ddate,
                DepartmentName = materialappm.Cdepname,
                Brand = materialappm.Cdefine8,
                MaterialOrderDetails = materialappm.Details.Select(d => d.GetDtoMaterialOrderDetail()).ToList()
            };
        }
        public static DtoMaterialOrderDetail GetDtoMaterialOrderDetail(this Data.Materialappd t)
        {
            return new DtoMaterialOrderDetail
            {
                Id = t.Autoid,
                Numbers = t.Iquantity.Value,
                ProductModel = t.Cinvstd,
                ProductName = t.Cinvname,
                ProductNumbers = t.Cinvcode,
                StoreCode = t.Cwhcode,
                StoreName = t.Cwhname,
                UnitName = t.CinvmUnit
            };
        }
        public static DtoSellOrder GetDtoSellOrder(this Data.DispatchList dispatchList)
        {
            return new DtoSellOrder()
            {
                Id = dispatchList.Dlid,
                CreateDate = dispatchList.DDate,
                Maker = dispatchList.CMaker,
                OrderNo = dispatchList.CDlcode,
                ReceiveCompany = dispatchList.CCusName,
                Receiver = dispatchList.Receiver,
                ReceiveTel = dispatchList.ReceiveTel,
                RecevieAddress = dispatchList.RecevieAddress,
                Remark = dispatchList.CMemo,
                SellOrderDetails = dispatchList.Details.Select(d => d.GetSellOrderDetail()).ToList()
            };
        }
        public static DtoSellOrder GetDtoSellOrder(this Data.SaDispatchlist dispatchList)
        {
            return new DtoSellOrder()
            {
                Id = dispatchList.Dlid,
                CreateDate = DateTime.Parse(dispatchList.Ddate),
                Maker = dispatchList.Cmaker,
                OrderNo = dispatchList.Cdlcode,
                ReceiveCompany = dispatchList.Ccusname,
                Receiver = dispatchList.Receiver,
                ReceiveTel = dispatchList.ReceiveTel,
                RecevieAddress = dispatchList.RecevieAddress,
                Remark = dispatchList.Cmemo,
                SellOrderDetails = dispatchList.Details.Select(d => d.GetSellOrderDetail()).ToList()
            };
        }
        public static DtoSellOrderDetail GetSellOrderDetail(this Data.DispatchLists dispatchLists)
        {
            return new DtoSellOrderDetail()
            {
                Id = dispatchLists.AutoId,
                IsBatchManage = dispatchLists.BInvBatch,
                Numbers = (dispatchLists.IQuantity ?? 0) - (dispatchLists.FOutQuantity ?? 0),
                ProcutModel = dispatchLists.CInvStd,
                ProductBatchNo = "",
                ProductName = dispatchLists.CInvName,
                ProductNumbers = dispatchLists.CInvCode,
                UnitName = dispatchLists.CComUnitName
            };
        }
        public static DtoPurchaseOrder GetDtoPurchaseOrder(this Data.PuArrHead puArrHead)
        {
            return new DtoPurchaseOrder()
            {
                Maker = puArrHead.Cmaker,
                Id = puArrHead.Id,
                OrderNo = puArrHead.Ccode,
                PurchaseOrderNo = puArrHead.Cpocode,
                OrderType = puArrHead.Cbustype,
                Remark = puArrHead.Cmemo,
                Supplier = puArrHead.Cvenname,
                SupplierCode = puArrHead.Cvencode,
                CreateDate = puArrHead.Ddate,
                StockOrderCode = puArrHead.RdRecordNo,
                SendOrderNo = puArrHead.SendOrderNo,
                Content = string.Join(",", puArrHead.Details.Select(b => $"{b.Cinvcode}{(string.IsNullOrEmpty(b.Cinvstd) ? string.Empty : "(" + b.Cinvstd + ")")}")),
                PurchaseOrderDetails = puArrHead.Details.Select(v => v.GetDtoPurchaseOrderDetail()).ToList()
            };
        }
        public static DtoPurchaseOrderDetail GetDtoPurchaseOrderDetail(this Data.PuArrbody puArrbody)
        {
            return new DtoPurchaseOrderDetail
            {
                AutoId = puArrbody.Autoid,
                Numbers = puArrbody.Iquantity,
                ProductModel = puArrbody.Cinvstd,
                ProductName = puArrbody.Cinvname,
                ProductNumbers = puArrbody.Cinvcode,
                ProductBatch = puArrbody.Cbatch,
                StoreCode = puArrbody.Cwhcode,
                StoreName = puArrbody.Cwhname,
                UnitName = puArrbody.CinvmUnit,
                Price = puArrbody.Ioritaxcost
            };
        }
        public static DtoMaterialOrder GetDtoMaterialOrder(this Data.OmMomain ommain)
        {
            return new DtoMaterialOrder
            {
                Maker = ommain.CMaker,
                Id = ommain.Moid,
                OrderNo = ommain.CCode,
                Remark = ommain.CMemo,
                CreateDate = ommain.DDate,
                DepartmentName = "",
                ProductModel = ommain.ProductModel,
                ProductName = ommain.ProductName,
                Brand = ommain.CDefine8,
                MaterialOrderDetails = ommain.Details.Select(d => d.GetDtoMaterialOrderDetail()).ToList()

            };
        }
        public static DtoMaterialOrderDetail GetDtoMaterialOrderDetail(this Data.OmModetails omModetails)
        {
            return new DtoMaterialOrderDetail
            {
                Id = omModetails.ModetailsId,
                Numbers = omModetails.INum ?? 0,
                ProductNumbers = omModetails.ProductNumbers,
                ProductBatch = "",
                ProductModel = omModetails.ProductModel,
                ProductName = omModetails.ProductName,
                StoreCode = "",
                StoreName = "",
                UnitName = ""
            };
        }
        public static DtoMaterialOrderDetail GetDtoMaterialOrderDetail(this Data.OmMomaterialsbody omMomaterialsbody)
        {
            return new DtoMaterialOrderDetail
            {
                Id = omMomaterialsbody.Momaterialsid,
                ProductName = omMomaterialsbody.Cinvname,
                ProductNumbers = omMomaterialsbody.Cinvcode,
                ProductBatch = "",
                ProductModel = omMomaterialsbody.Cinvstd,
                Numbers = omMomaterialsbody.Iquantity.Value - (omMomaterialsbody.Isendqty ?? 0),
                StoreCode = omMomaterialsbody.Cwhcode,
                StoreName = omMomaterialsbody.Cwhname,
                UnitName = omMomaterialsbody.CinvmUnit
            };
        }
        public static DtoInventoryStock GetDtoInventoryStock(this Data.CurrentStock stock)
        {
            return new DtoInventoryStock()
            {
                Numbers = stock.IQuantity ?? 0,
                ProductBatchNo = stock.CBatch,
                StoreCode = stock.CWhCode,
                StoreName = stock.WhName
            };
        }
        public static DtoInventory GetDtoInventory(this Data.Inventory product)
        {
            return new DtoInventory()
            {
                ProductName = product.CInvName,
                ProductNumbers = product.CInvCode,
                ProductModel = product.CInvStd,
                Rate = product.ITaxRate.GetValueOrDefault(),
                InventoryClassCode = product.CInvCcode,
                InventoryClassName = product.InvClassName,
                UnitName = product.UnitName,
                InventoryStocks = product.Stock.Select(s => s.GetDtoInventoryStock()).ToList(),
                MaxStoreNumbers = product.ITopSum,
                MinStoreNumbers = product.ILowSum
            };
        }

        public static DtoPurchaseOrder GetDtoPurchaseOrder(this Data.PoPomain t)
        {
            return new DtoPurchaseOrder()
            {
                CreateDate = t.DPodate,
                Id = t.Poid,
                Maker = t.CMaker,
                MaxArriveDate = t.MaxArriveDate,
                OrderNo = t.CPoid,
                OrderType = t.CBusType,
                SupplierCode = t.SupplierCode,
                Remark = t.CMemo,
                State = t.CDefine9 ?? "待处理",
                PurchaseOrderNo = t.CPoid,
                Supplier = t.CVenAccount,
                PurchaseOrderDetails = t.Details.Select(d => d.GetDtoPurchaseOrderDetail()).ToList()
            };
        }

        public static DtoPurchaseOrderDetail GetDtoPurchaseOrderDetail(this Data.PoPodetails t)
        {
            return new DtoPurchaseOrderDetail()
            {
                AutoId = t.Id,
                ArriveDate = t.DArriveDate,
                //Id = t.Id,
                Numbers = t.IQuantity.Value - (t.IReceivedQty ?? 0),
                ProductModel = t.ProductModel,
                ProductName = t.ProductName,
                ProductNumbers = t.CInvCode,
                UnitName = t.UnitName,
                Price = t.INatUnitPrice,
                Rate = 0m
            };
        }

        public static DtoPurchaseOrderDetail GetDtoPurchaseOrderDetail(this Data.Zpurpotail t)
        {
            return new DtoPurchaseOrderDetail()
            {
                AutoId = t.Id,
                ArriveDate = t.Darrivedate,
                //Id = t.Id,
                Numbers = t.Iquantity.Value - (t.Ireceivedqty ?? 0),
                ProductModel = t.Cinvstd,
                ProductName = t.Cinvname,
                ProductNumbers = t.Cinvccode,
                UnitName = t.CinvmUnit,
                Price = t.Inatunitprice,
                Rate = 0m
            };
        }

        public static DtoAllotOrder GetDtoAllotOrder(this Data.RdRecord09 rdRecord)
        {
            return new DtoAllotOrder()
            {
                AllotOrderNo = rdRecord.CBusCode,
                OrderNo = rdRecord.CCode,
                CreateTime = rdRecord.DDate,
                Remark = rdRecord.CMemo,
                Brand = rdRecord.Brand,
                TargetBrand = rdRecord.TargetBrand,
                TargetStoreName = rdRecord.InWhName,
                SourceStoreName = rdRecord.OutWhName,
                AllotOrderDetails = rdRecord.Details.Select(d => d.GetDtoAllotOrderDetail()).ToList(),
            };
        }

        public static DtoAllotOrderDetail GetDtoAllotOrderDetail(this Data.Rdrecords09 rdrecord)
        {
            return new DtoAllotOrderDetail()
            {
                AutoId = rdrecord.AutoId,
                ProductBathcNo = rdrecord.CBatch,
                ProductName = rdrecord.ProductName,
                ProductNumbers = rdrecord.CInvCode,
                Numbers = rdrecord.IQuantity ?? 0,
                ProductModel = rdrecord.ProductModel,
                UnitName = rdrecord.UnitName
            };
        }

        public static DtoAllotOutRecord GetDtoAllotOutOrder(this Data.RdRecord09 rdRecord)
        {
            return new DtoAllotOutRecord()
            {
                OrderNo = rdRecord.CCode,
                CreateTime = rdRecord.DDate,
                Remark = rdRecord.CMemo,
                Brand = rdRecord.CDefine8,
                StoreName = rdRecord.OutWhName,
                AllotOutRecordDetails = rdRecord.Details.Select(d => d.GetDtoAllotOutRecordDetail()).ToList()
            };
        }

        public static DtoAllotOutRecordDetail GetDtoAllotOutRecordDetail(this Data.Rdrecords09 rdrecords)
        {
            return new DtoAllotOutRecordDetail()
            {
                OrderNo = rdrecords.OrderNo,
                ProductBathcNo = rdrecords.CBatch,
                ProductName = rdrecords.ProductName,
                ProductNumbers = rdrecords.CInvCode,
                Numbers = rdrecords.IQuantity ?? 0,
                ProductModel = rdrecords.ProductModel,
                UnitName = rdrecords.UnitName,
            };
        }

        public static DtoAllotInRecord GetDtoAllotInOrder(this Data.RdRecord08 rdRecord)
        {
            return new DtoAllotInRecord()
            {
                OrderNo = rdRecord.CCode,
                CreateTime = rdRecord.DDate,
                Remark = rdRecord.CMemo,
                Brand = rdRecord.CDefine8,
                StoreName = rdRecord.WhName,
                AllotInRecordDetails = rdRecord.Details.Select(d => d.GetDtoAllotInRecordDetail()).ToList()
            };
        }

        public static DtoAllotInRecordDetail GetDtoAllotInRecordDetail(this Data.Rdrecords08 rdrecords)
        {
            return new DtoAllotInRecordDetail
            {
                ProductName = rdrecords.ProductName,
                ProductNumbers = rdrecords.CInvCode,
                Numbers = rdrecords.IQuantity ?? 0,
                ProductModel = rdrecords.ProductModel,
                UnitName = rdrecords.UnitName,
            };
        }

        public static DtoAllotRecord GetDtoAllotRecord(this Data.Rdrecords09 rdrecords09)
        {
            return new DtoAllotRecord()
            {
                AutoId = rdrecords09.AutoId,
                OrderNo = rdrecords09.OrderNo,
                CreateTime = rdrecords09.CreateTime,
                Remark = rdrecords09.Remark,
                Brand = rdrecords09.Brand,
                StoreName = rdrecords09.StoreName,
                ProductBathcNo = rdrecords09.CBatch,
                ProductName = rdrecords09.ProductName,
                ProductNumbers = rdrecords09.ProductNumbers,
                Numbers = rdrecords09.IQuantity ?? 0,
                ProductModel = rdrecords09.ProductModel,
                UnitName = rdrecords09.UnitName
            };
        }

        public static DispatchBill GetDispatchBill(this Data.DispatchList dispatchList)
        {
            var state = DispatchBillState.All;
            if (dispatchList.CChangeMemo is null && !dispatchList.Dverifysystime.HasValue)
            {
                state = DispatchBillState.Processing;
            }
            else if (dispatchList.CChangeMemo != null && dispatchList.CChangeMemo.StartsWith("待发货"))
            {
                state = DispatchBillState.Sending;
            }
            else if (dispatchList.Dverifysystime.HasValue)
            {
                state = DispatchBillState.Completed;
            }

            return new DispatchBill
            {
                BillNo = dispatchList.CDlcode,
                Brand = dispatchList.CDefine8,
                Customer = dispatchList.CCusName,
                Date = dispatchList.DDate,
                Maker = dispatchList.CMaker,
                SoBillNo = dispatchList.CSocode,
                OutNos = dispatchList.CSaleOut,
                State = state,
                CusPerson = dispatchList.Ccusperson,
                ShipAddress = dispatchList.CShipAddress,
                Address = dispatchList.CDefine11,
                Receiver = dispatchList.CDefine13,
                ReceiverTel = dispatchList.CDefine14,
                Station = dispatchList.CDefine10
            };
        }

        public static DispatchBillDetail GetDispatchBillDetail(this Data.DispatchLists dispatchLists)
        {
            return new DispatchBillDetail
            {
                BillNo = dispatchLists.CbSysBarCode,
                Batch = dispatchLists.CBatch,
                Id = dispatchLists.AutoId.ToString(),
                InvCode = dispatchLists.CInvCode,
                InvName = dispatchLists.CInvName,
                TotalQty = dispatchLists.IQuantity ?? 0,
                Qty = (dispatchLists.IQuantity ?? 0) - (dispatchLists.FOutQuantity ?? 0),
                WhCode = dispatchLists.CWhCode,
                WhName = dispatchLists.CWhCodeNavigation?.CWhName ?? ""
            };
        }

    }
}
