/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ID]
      ,[Rating]
      ,[Comments]
      ,[tblRestaurantID]
      ,[tblCustomerId]
      ,[UserCreated]
      ,[UserModified]
      ,[RecordTimeStamp]
      ,[RecordTimeStampCreated]
  FROM [ReviewManagement].[dbo].[tblRating]

  Insert into [ReviewManagement].[dbo].[tblRating] values (5,'Good',1,123,1,1,'1996-09-09 00:00:00.000','1996-09-09 00:00:00.000')
Insert into [ReviewManagement].[dbo].[tblRating] values (2,'Avg',2,234,6,6,'1996-09-09 00:00:00.000','1996-09-09 00:00:00.000')

go