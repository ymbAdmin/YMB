/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [id]
      ,[paycheck]
      ,[paycheckDate]
  FROM [yellowmu_ymbSite].[dbo].[Paychecks]

--  update dbo.paychecks set paycheckDate	= '2017-02-23 00:00:00.000'