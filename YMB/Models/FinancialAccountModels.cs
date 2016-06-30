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
        public string acctName { get; set; }
        public int acctType { get; set; }
    }
}