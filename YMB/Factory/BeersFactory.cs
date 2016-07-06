using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YMB.Models;

namespace YMB.Factory
{
    public class BeersFactory
    {
        public const string COMING_SOON_IMAGE_URL = "images/coming-soon.jpg";

        private static ApplicationDbContext _db = new ApplicationDbContext();

        internal static IEnumerable<Beers> GetBeerList()
        {
            List<Beers> beerList = new List<Beers>();
            beerList = _db.Beers.ToList();

            foreach (var beer in beerList)
            {
                beer.beerImages = GetBeerImages(beer.beerId);
            }
                //db.Beers.
            return beerList;
        }

        internal static List<string> GetBeerImages(int beerId)
        {
            List<string> beerImageList = new List<string>();

            var query = from i in _db.BeerImages
                        where i.beerId == beerId
                        select i.imageURL;

            foreach (string imageURL in query)
            {
                beerImageList.Add(imageURL);
            }
            
            //if no images assign Coming Soon image
            if (beerImageList.Count < 1){
                beerImageList.Add(COMING_SOON_IMAGE_URL);
            }
            return beerImageList;
        }
    }
}