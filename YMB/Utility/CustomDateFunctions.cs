using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YMB.Utility
{
    public class CustomDateFunctions
    {
        public static DateTime GetDateTime() 
        {
            return DateTime.UtcNow.AddHours(-5); 
        }
    }
}