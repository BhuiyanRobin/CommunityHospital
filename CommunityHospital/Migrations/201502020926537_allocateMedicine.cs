namespace CommunityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allocateMedicine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllocateMedicines", "ADistrict_DistrictId", c => c.Int());
            AddColumn("dbo.AllocateMedicines", "AThana_ThanaId", c => c.Int());
            CreateIndex("dbo.AllocateMedicines", "ADistrict_DistrictId");
            CreateIndex("dbo.AllocateMedicines", "AThana_ThanaId");
            AddForeignKey("dbo.AllocateMedicines", "ADistrict_DistrictId", "dbo.Districts", "DistrictId");
            AddForeignKey("dbo.AllocateMedicines", "AThana_ThanaId", "dbo.Thanas", "ThanaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocateMedicines", "AThana_ThanaId", "dbo.Thanas");
            DropForeignKey("dbo.AllocateMedicines", "ADistrict_DistrictId", "dbo.Districts");
            DropIndex("dbo.AllocateMedicines", new[] { "AThana_ThanaId" });
            DropIndex("dbo.AllocateMedicines", new[] { "ADistrict_DistrictId" });
            DropColumn("dbo.AllocateMedicines", "AThana_ThanaId");
            DropColumn("dbo.AllocateMedicines", "ADistrict_DistrictId");
        }
    }
}
