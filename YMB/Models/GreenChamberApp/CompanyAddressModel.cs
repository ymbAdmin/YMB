using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YMB.Models.GreenChamberApp
{
    public class CompanyAddress
    {
        [Key]
        public int Id { get; set; }
        // public Company Company { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}