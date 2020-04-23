select *from Person where cPersonName = 'µË°²Æ½'
select * from OM_MOMaterials  where MoDetailsID=1000000609

select * from customer
select * from Inventory
select * from InventoryClass
select * from Warehouse
select ccusperson ,dclosesystime,dclosedate,* from SO_SOMain 
select * from SO_SODetails
select * from SaleOrderSQ

select * from SA_SNDetail_Disp
select * from EnDispatch
select outid ,cSaleOut ,iverifystate ,* from Dispatchlist
select * from  dbo.crm_sa_dispatch 
select * from SA_Dispatchlist where DLID=1000000016
select * from DispatchLists where dlid=1000000016
select * from dbo.SA_DispProfit where dlid=1000000016
select  * from dbo.sa_dispatchmainmerp where dlid=1000000016
select  * from dbo.sa_dispatchdetailmerp  where dlid=1000000016

select * from Inventory where cInvCode=323110015