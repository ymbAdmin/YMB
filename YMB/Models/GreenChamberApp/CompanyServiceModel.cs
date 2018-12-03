using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YMB.Models.GreenChamberApp
{
    public class CompanyService
    {
        [Key]
        public int Id { get; set; }
        // public Company Company { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
    }
}