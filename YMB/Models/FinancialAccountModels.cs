using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YMB.Models
{
    public class Accounts
    {
        [Key]
        public int acctId { get; set; }
        [Display(Name="Account Name")]
        public string acctName { get; set; }
        public int acctType { get; set; }
        [Display(Name = "Account Transactions")]
        public List<AccountTransactions> acctTrans { get; set; }
        [Display(Name = "Account Balance")]
        public decimal? acctBalance { get; set; }
    }

    public class AccountTransactions
    {
        [Key]
        public int tranId { get; set; }
        public int acctId { get; set; }
        public string tranDesc { get; set; }
        public int tranType { get; set; }
        public DateTime tranDate { get; set; }
        public decimal tranAmount { get; set; }
        public decimal acctBalance { get; set; }

    }
}