using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YMB.Models;

namespace YMB.Factory
{
    public class FootballPoolFactory
    {
        private static ApplicationDbContext _db = new ApplicationDbContext();
        private const string FOOTBALL_ROLE = "FootballPool";
        internal static void RegisterUserForPool(string userId, int simpleUserId, string userName)
        {
            //add role 3 to userName
            AddUserToRole(userId, FOOTBALL_ROLE);
            //flip flag on users entry

            //add user to football users table
        }

        internal static void AddUserToRole(string userId, string roleName)
        {
            var store = new UserStore<ApplicationUser>(_db);
            var manager = new UserManager<ApplicationUser>(store);
            manager.AddToRole(userId,roleName);

        }

    }
}