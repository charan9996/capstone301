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
 