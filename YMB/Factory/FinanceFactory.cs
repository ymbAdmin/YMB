using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using YMB.Models;
using YMB.Utility;

namespace YMB.Factory
{
    public class FinanceFactory
    {
        

        internal static List<Accounts> GetAccounts()
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            List<Accounts> acctList = _db.Accounts.OrderBy(a => a.acctType).ThenBy(a => a.acctBalance).ToList();
            foreach (var acct in acctList)
            {
                if (acct.acctBillDueDate < CustomDateFunctions.GetDateTime())
                {
                    UpdateBillDueDate(acct.acctBillDueDate.Value.AddMonths(1), acct.acctId);//this updates the DB
                    acct.acctBillDueDate = acct.acctBillDueDate.Value.AddMonths(1);//for showing on the screen without reload
                }
            }
            return acctList;
        }

        internal static List<AccountTransactions> GetAccountTransactions(int acctId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            List<AccountTransactions> acctTrans = new List<AccountTransactions>();
            var results = _db.AccountTransactions.SqlQuery(String.Format("EXEC GetAccountTransactions @acctId = {0}", acctId));
            foreach (var tran in results)
            {
                acctTrans.Add(tran);
            }

            return acctTrans;
        }

        internal static void DeleteTransaction(int acctId, int tranId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            _db.AccountTransactions.Remove(_db.AccountTransactions.Find(tranId));
            var previsouAccountBalance = GetPreviousAccountBalance(acctId);
            UpdateAccountBalance(acctId, previsouAccountBalance);
            _db.SaveChanges();
        }

        internal static decimal GetTotalValueOfAccounts(List<Accounts> accounts, int acctType)
        {
            decimal total = 0.0M;
            accounts = accounts.Where(a => a.acctType == acctType).ToList();
            foreach (var account in accounts)
            {
                total += (decimal)account.acctBalance;
            }
            return total;
        }

        internal static void AddTransaction(int acctId, int tranType, string tranDesc, decimal tranAmount, int acctType, Boolean pending)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            //I also have a sproc for this ymb_Add_Account_Transaction
            decimal prevBal = GetCurrentAccountBalance(acctId);
            decimal newBal = GetAccountNewBalance(tranAmount, prevBal, tranType, acctType);
            AccountTransactions newTran = new AccountTransactions() { acctId = acctId, tranAmount = tranAmount, tranDesc = tranDesc, tranType = tranType, tranDate = DateTime.Now, acctBalance = newBal, pending = pending };
            _db.AccountTransactions.Add(newTran);
            //_db.AccountTransactions.SqlQuery(String.Format("EXEC ymb_Add_Account_Transaction {0},{1},{2},{3}", acctId, tranDesc, tranType, tranAmount));
            UpdateAccountBalance(acctId, newBal);
            _db.SaveChanges();
        }

        private static void UpdateAccountBalance(int acctId, decimal newBal)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            Accounts acct = _db.Accounts.Where(a => a.acctId == acctId).First<Accounts>();
            acct.acctBalance = newBal;
            _db.Entry(acct).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        internal static void UpdatePaycheckDate(DateTime newDate)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            Paycheck paycheck = _db.Paycheck.First<Paycheck>();
            paycheck.paycheckDate = newDate;
            _db.Entry(paycheck).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        internal static void UpdateBillDueDate(DateTime newDate, int acctId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            Accounts thisAcct = _db.Accounts.Where(a => a.acctId == acctId).FirstOrDefault();
            thisAcct.acctBillDueDate = newDate;
            _db.Entry(thisAcct).State = System.Data.Entity.EntityState.Modified;
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

        internal static decimal GetPreviousAccountBalance(int acctId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();

            var tranIds = _db.AccountTransactions.OrderByDescending(at => at.tranId).Where(at => at.acctId == acctId).Select(at => at.tranId).Take(2);

            var previousTranId = tranIds.Min();

            var previousBalance = _db.AccountTransactions.Where(at => at.tranId == previousTranId && at.acctId == acctId).Select(at => at.acctBalance).Take(1);

            return previousBalance.First<decimal>();
            //return 0.00M;
        }

        internal static decimal GetCurrentAccountBalance(int acctId)
        {

            ApplicationDbContext _db = new ApplicationDbContext();

            var tranIds = _db.AccountTransactions.Where(at => at.acctId == acctId).Select(at => at.tranId);

            var latestTranId = tranIds.Max();

            var previousBalance = _db.AccountTransactions.Where(at => at.tranId == latestTranId && at.acctId == acctId).Select(at => at.acctBalance).Take(1);

            return previousBalance.First<decimal>(); 
        }

        internal static void PendingTransaction(int acctId, int tranId)
        {
   
            ApplicationDbContext _db = new ApplicationDbContext();
            AccountTransactions acctTran = _db.AccountTransactions.Where(a => a.tranId == tranId).First<AccountTransactions>();
            acctTran.pending = false;
            _db.Entry(acctTran).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        internal static List<Accounts> GetBillsDue(DateTime thisPaycheckDate, DateTime nextPaycheckDate)
        {
            List<Accounts> acctsWithBillsDueThisPaycheck = new List<Accounts>();
            ApplicationDbContext _db = new ApplicationDbContext();
            acctsWithBillsDueThisPaycheck = _db.Accounts.Where(a => a.acctBillDueDate >= thisPaycheckDate && 
                                                               a.acctBillDueDate < nextPaycheckDate).ToList();

            return acctsWithBillsDueThisPaycheck;
        }
    }
}