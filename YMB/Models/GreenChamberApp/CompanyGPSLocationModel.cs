
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YMB.Models.GreenChamberApp
{
    public class CompanyGPSLocation
    {
        [Key]
        public int Id { get; set; }
        // public Company Company { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}