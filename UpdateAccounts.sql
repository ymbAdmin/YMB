/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [acctId]
      ,[acctName]
      ,[acctType]
      ,[acctBalance]
      ,[acctBillDueDate]
      ,[acctBillDueAmount]
      ,[display]
  FROM [yellowmu_ymbSite].[dbo].[Accounts]



--EXEC	[dbo].[UpdateAccount] @AcctId = 8,@AcctBalance = NULL,@AcctBillDueDate = '2017-04-10 00:00:00.000',@AcctBillDueAmount = 170.75,@Display = NULL
