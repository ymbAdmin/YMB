using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YMB.Models
{
    public class Requests
    {
        public Requests(int RequestId, string ReqName, string ReqEmail, string ReqAddr, string ReqState, string RegCity, string ReqZip, string Comments)
        {
            this.requestId = RequestId;
            this.requesterName = ReqName;
            this.requesterEmail = ReqEmail;
            this.requesterAddress = ReqAddr;
            this.requesterState = ReqState;
            this.requesterCity = RegCity;
            this.requesterZip = ReqZip;
            this.comments = Comments;
            this.isProcessed = false;
            this.dateRequested = DateTime.Now;
        }

        [Key]
        public int id { get; set; }
        public int requestId { get; set; }
        [Display(Name="Name")]
        public string requesterName { get; set; }
        [Display(Name = "Email")]
        public string requesterEmail { get; set; }
        [Display(Name = "Mailing Address")]
        public string requesterAddress { get; set; }
        [Display(Name = "State")]
        public string requesterState { get; set; }
        [Display(Name = "City")]
        public string requesterCity { get; set; }
        [Display(Name = "Zip")]
        public string requesterZip { get; set; }
        [Display(Name = "Name")]
        public string comments { get; set; }
        public Boolean isProcessed { get; set; }
        public DateTime dateRequested { get; set; }
    }
}