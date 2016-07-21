using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using YMB.Models;

namespace YMB.Factory
{
    public class AccountsFactory
    {
        private static ApplicationDbContext _db = new ApplicationDbContext();

        internal static List<AccountTransactions> GetAccountTransactions(int acctId)
        {
            List<AccountTransactions> acctTrans = new List<AccountTransactions>();
            var results = _db.AccountTransactions.SqlQuery(String.Format("EXEC ymb_Get_Account_Transactions @acctId = {0}", acctId));
            foreach (var tran in results)
            {
                acctTrans.Add(tran);
            }

            return acctTrans;
        }

        internal static void DeleteTransaction(int acctId, int tranId)
        {
            _db.AccountTransactions.Remove(_db.AccountTransactions.Find(tranId));
            UpdateAccountBalance(acctId, GetAccountPreviousBalance(acctId));
            _db.SaveChanges();
        }

        internal static void AddTransaction(int acctId, int tranType, string tranDesc, decimal tranAmount, int acctType)
        {
            //I also have a sproc for this ymb_Add_Account_Transaction
            decimal prevBal = GetAccountPreviousBalance(acctId);
            decimal newBal = GetAccountNewBalance(tranAmount, prevBal, tranType, acctType);
            AccountTransactions newTran = new AccountTransactions() { acctId = acctId, tranAmount = tranAmount, tranDesc = tranDesc, tranType = tranType, tranDate = DateTime.Now, acctBalance = newBal };
            _db.AccountTransactions.Add(newTran);
            //_db.AccountTransactions.SqlQuery(String.Format("EXEC ymb_Add_Account_Transaction {0},{1},{2},{3}", acctId, tranDesc, tranType, tranAmount));
            UpdateAccountBalance(acctId, newBal);
            _db.SaveChanges();
        }

        private static void UpdateAccountBalance(int acctId, decimal newBal)
        {
            Accounts acct = _db.Accounts.Where(a => a.acctId == acctId).First<Accounts>();
            acct.acctBalance = newBal;
            _db.Entry(acct).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        internal static void UpdatePaycheckDate(DateTime newDate)
        {
            Paycheck paycheck = _db.Paycheck.First<Paycheck>();
            paycheck.paycheckDate = newDate;
            _db.Entry(paycheck).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        private static decimal GetAccountNewBalance(decimal tranAmount, decimal prevBal, int tranType, int acctType)
        {
            if (tranType == 1)//subtract
            {
                if(acctType == 1){
                    return prevBal - tranAmount;
                }else{
                    return prevBal + tranAmount;
                }
            }
            else if (tranType == 2)//add
            {
                if (acctType == 1){
                    return prevBal + tranAmount;
                }else{
                    return prevBal - tranAmount;
                }
            }
            return prevBal;
        }

        internal static decimal GetAccountPreviousBalance(int acctId)
        {
            
            var tranIds = from i in _db.AccountTransactions
                        where i.acctId == acctId
                        select  i.tranId;

            var lastTranId = tranIds.Max();


            var previousBalance = from j in _db.AccountTransactions
                                  where j.tranId == lastTranId && j.acctId == acctId
                                  select j.acctBalance;

            return previousBalance.First<decimal>(); 
        }
    }
}