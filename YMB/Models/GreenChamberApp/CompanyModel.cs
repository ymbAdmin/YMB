using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMB.Utility;

namespace YMB.Models.GreenChamberApp
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public List<CompanyService> Services {get; set; }
        public long PhoneNumber { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        [DecimalPrecision(20, 10)]
        public decimal Longitude { get; set; }
        [DecimalPrecision(20, 10)]
        public decimal Latitude { get; set; }

    }
}