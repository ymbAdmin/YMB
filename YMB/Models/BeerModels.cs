using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YMB.Models
{
    public class Beers
    {
        [Key]
        public int beerId { get; set; }
        [Display(Name="Beer")]
        public string beerName { get; set; }
        [Display(Name = "Style")]
        public string beerStyle { get; set; }
        [Display(Name = "ABV %")]
        public decimal? beerABV { get; set; }
        [Display(Name = "Calories")]
        public int? beerCalories { get; set; }
        [Display(Name = "IBUs")]
        public int? beerIBU { get; set; }
        [Display(Name = "Description")]
        public string beerDesc { get; set; }
        public List<string> beerImages { get; set; }
    }

    public class BeerImages
    {
        [Key]
        public int imageId { get; set; }
        public int beerId { get; set; }
        public string imageURL { get; set; }
    }
}