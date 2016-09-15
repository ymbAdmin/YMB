using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YMB.Models;

namespace YMB.Factory
{
    public class LoggerFactory
    {
        private static void Log(int eventCatId, string source, string eventDesc, string eventDetails, string simpleUserId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
           _db.AppEvent.Add(new AppEvent() { eventCategoryId = eventCatId, 
                                                eventDate = DateTime.UtcNow, 
                                                eventSource = source, 
                                                eventDescription = eventDesc, 
                                                eventDetails = eventDetails,
                                                simpleUserId = simpleUserId });
           _db.SaveChanges();
        }

        internal static void LogInfo(string source, string eventDesc, string eventDetails, string simpleUserId){
            Log(2, source, eventDesc, eventDetails, simpleUserId);
        }

        internal static void LogError(string source, string eventDesc, string eventDetails, string simpleUserId)
        {
            Log(1,source,eventDesc,eventDetails, simpleUserId);
        }
    }
}