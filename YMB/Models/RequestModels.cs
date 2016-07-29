using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YMB.Models
{
    public class Requests
    {
        public Requests() { }

        public Requests(string RequestType, string ReqName, string ReqEmail, string ReqAddr, string ReqState, string RegCity, string ReqZip, string Comments)
        {
            this.requestType = RequestType;
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
        [Display(Name = "Request Type")]
        public string requestType { get; set; }
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
        [Display(Name = "Date")]
        public DateTime dateRequested { get; set; }
    }
}