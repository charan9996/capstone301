/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ID]
      ,[Item]
      ,[tblCuisineID]
      ,[UserCreated]
      ,[UserModified]
      ,[RecordTimeStamp]
      ,[RecordTimeStampCreated]
      ,[Quantity]
  FROM [RestaurantManagement].[dbo].[tblMenu]
  go
  select * from [RestaurantManagement].[dbo].TblRestaurant join [RestaurantManagement].[dbo].tblLocation  on [RestaurantManagement].[dbo].TblRestaurant.TblLocationId =[RestaurantManagement].[dbo].tblLocation .Id 
      go
	  
	                                 