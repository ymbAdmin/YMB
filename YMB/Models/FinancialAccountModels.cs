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
        [Display(Name = "Account Name")]
        public string acctName { get; set; }
        public int acctType { get; set; }
        [Display(Name = "Account Transactions")]
        public List<AccountTransactions> acctTrans { get; set; }
        [Display(Name = "Account Balance")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? acctBalance { get; set; }
        [Display(Name = "Bill Due Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime? acctBillDueDate { get; set; }
        [Display(Name = "Amount Due")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? acctBillDueAmount { get; set; }
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

    public class Paycheck
    {
        [Key]
        public int id { get; set; }
        public string paycheck { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime paycheckDate { get; set; }
    }
}