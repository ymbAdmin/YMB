using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using YMB.Models;

namespace YMB.Factory
{
    public class UtilFactory
    {
        internal static ApplicationDbContext AddUserToRole(string userId, string roleName, ApplicationDbContext db)
        {
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store);
            if (!manager.IsInRole(userId, roleName))
            {
                try
                {
                    manager.AddToRole(userId, roleName);
                }
                catch (Exception e)
                {
                    LoggerFactory.LogError("AddUserToRole", string.Format("Trouble adding user Id: {0} because {1}", userId, e.InnerException.Message), e.StackTrace, userId);
                }
            }
            return db;
        }
    }
}