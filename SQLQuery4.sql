/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ID]
      ,[X]
      ,[Y]
      ,[UserCreated]
      ,[UserModified]
      ,[RecordTimeStamp]
      ,[RecordTimeStampCreated]
  FROM [RestaurantManagement].[dbo].[tblLocation]
  go


