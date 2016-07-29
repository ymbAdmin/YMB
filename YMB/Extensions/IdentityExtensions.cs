using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace YMB.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetSimpleUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("simpleUserId");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string IsUserPlayingPool(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("isPlayingFootballPool");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserFirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("firstName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}