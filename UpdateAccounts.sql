/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [acctId]
      ,[acctName]
      ,[acctType]
      ,[acctBalance]
      ,[acctBillDueDate]
      ,[acctBillDueAmount]
      ,[display]
  FROM [yellowmu_ymbSite].[dbo].[Accounts]



--USE yellowmu_ymbSite EXEC	[yellowmu_ymbSite].[dbo].[UpdateAccount] @AcctId = 3,@AcctBalance = NULL,@AcctBillDueDate = '2017-04-15 00:00:00.000',@AcctBillDueAmount = 250.00,@Display = NULL
