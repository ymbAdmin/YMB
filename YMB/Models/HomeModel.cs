using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YMB.Models
{
    public class HomeModel
    {
        public IEnumerable<Beers> beerList { get; set; }
    }
}