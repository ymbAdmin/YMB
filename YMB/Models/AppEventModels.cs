using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YMB.Models
{
    public class AppEvent
    {
        [Key]
        public int id { get; set; }
        public int eventCategoryId { get; set; }
        public DateTime eventDate { get; set; }
        public string eventSource { get; set; }
        public string eventDescription { get; set; }
        [Column(TypeName = "text")]
        public string eventDetails { get; set; }
        public string simpleUserId { get; set; }
    }
}