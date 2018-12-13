namespace YMB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Industry = c.String(),
                        PhoneNumber = c.Long(nullable: false),
                        StreetNumber = c.Int(nullable: false),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        ServiceDescription = c.String(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyServices", "Company_Id", "dbo.Companies");
            DropIndex("dbo.CompanyServices", new[] { "Company_Id" });
            DropTable("dbo.CompanyServices");
            DropTable("dbo.Companies");
        }
    }
}
