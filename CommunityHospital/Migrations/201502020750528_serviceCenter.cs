namespace CommunityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceCenter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceCenters",
                c => new
                    {
                        ServiceCenterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Password = c.String(),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceCenterId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Thanas", t => t.ThanaId, cascadeDelete: true)
                .Index(t => t.DistrictId)
                .Index(t => t.ThanaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceCenters", "ThanaId", "dbo.Thanas");
            DropForeignKey("dbo.ServiceCenters", "DistrictId", "dbo.Districts");
            DropIndex("dbo.ServiceCenters", new[] { "ThanaId" });
            DropIndex("dbo.ServiceCenters", new[] { "DistrictId" });
            DropTable("dbo.ServiceCenters");
        }
    }
}
