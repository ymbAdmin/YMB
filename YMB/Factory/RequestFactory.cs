using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YMB.Models;

namespace YMB.Factory
{
    public class RequestFactory
    {
        internal static ApplicationDbContext _db = new ApplicationDbContext();

        internal static List<Requests> GetRequests()
        {
            List<Requests> myRequests = new List<Requests>();
            myRequests = _db.Requests.ToList();
            return myRequests;
        }

        internal static void SendRequest(string reqType, string name, string email, string addr, string state, string city, string zip, string comments)
        {
            Requests newRequest = new Requests(reqType, name, email, addr, state, city, zip, comments);
            _db.Requests.Add(newRequest);
            _db.SaveChanges();
        }

        internal static void ProcessRequest(int reqId)
        {
            
            Requests newRequest = _db.Requests.Where(r => r.id == reqId).First<Requests>();
            newRequest.isProcessed = true;
            _db.Entry(newRequest).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        internal static void UnprocessRequest(int reqId)
        {

            Requests newRequest = _db.Requests.Where(r => r.id == reqId).First<Requests>();
            newRequest.isProcessed = false;
            _db.Entry(newRequest).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        internal static string GetString(string disString){
            return disString;
        }

        internal static void TestMe(){
            GetString("test");
        }



        internal static void DeleteRequest(int reqId)
        {
            Requests thisRequest = _db.Requests.Where(r => r.id == reqId).First<Requests>();
            _db.Requests.Attach(thisRequest);
            _db.Requests.Remove(thisRequest);
            _db.SaveChanges();
        }
    }
}