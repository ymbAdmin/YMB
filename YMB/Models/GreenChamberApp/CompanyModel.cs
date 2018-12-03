using System.ComponentModel.DataAnnotations;


namespace YMB.Models.GreenChamberApp
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        //public CompanyService[] Services {get; set; }
        //public CompanyGPSLocation Location { get; set; }
        //public CompanyAddress Address { get; set; }
        public long PhoneNumber { get; set; }
        
    }
}