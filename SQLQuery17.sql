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

  Insert into [RestaurantManagement].[dbo].[Tblstock] values (3)

  select * from [RestaurantManagement].[dbo].[Tblstock]