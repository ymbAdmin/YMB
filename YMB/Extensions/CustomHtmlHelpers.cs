using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using YMB.Models;

namespace YMB.Extensions
{
    public static class CustomHtmlHelpers
    {

        public static MvcHtmlString UserDropDownList<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            var users = _db.FootballPoolUser.ToList();
            Dictionary<string, string> userList = new Dictionary<string, string>();

            foreach (var user in users)
            {
                userList.Add(user.simpleUserId.ToString(), user.userName.ToString());
            }

            return html.DropDownListFor(expression, new SelectList(userList, "key", "value"), "User");
        }
    }
}