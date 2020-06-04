# 用友类库 （U8 13.0）EFCORE反向工程实现

## 需要反向其他表或视图时，可以使用以下命令

在PowerShell下运行

    dotnet ef dbcontext scaffold "server=192.168.12.19;database=UFDATA_999_2019;user id=microfeel;password=123.com" Microsoft.EntityFrameworkCore.SqlServer -c U8DbContext -t PU_ArrivalVouch -t ComputationUnit -t Department -t Warehouse -t Vendor -t MaterialAppVouch  -t MaterialAppVouchs -t DispatchList -t DispatchLists -t Customer -t InventoryClass -t Inventory -t Om_Momain -t Om_Modetails -t Person -t TransVouch -t Po_Pomain -t Po_Podetails -t Om_Momaterials -t Pu_ArrivalVouchs  -t RdRecord01 -t RdRecord08 -t RdRecord09 -t RdRecord11 -t RdRecord32 -t RdRecord34 -t RdRecords01 -t RdRecords08 -t RdRecords09 -t RdRecords11 -t RdRecords32 -t RdRecords34 -t So_Somain -t So_Sodetails -t pu_ArrHead -t pu_ArrBody -t Om_Momaterialshead -t om_momaterialsbody -t SaleOrderSQ -t SA_Dispatchlist -t sa_dispatchmainmerp -t sa_dispatchdetailmerp -t materialappm -t materialappd -t CurrentStock -t zpurpotail -t SCM_ITEM -f -r Data

EFCore 3.0+ 视图将自动反向为 ToView