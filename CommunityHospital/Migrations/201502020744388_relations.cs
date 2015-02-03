namespace CommunityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DistrictThanaRelationships",
                c => new
                    {
                        DistrictThanaRelationshipId = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictThanaRelationshipId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            AddColumn("dbo.Thanas", "DistrictThanaRelationship_DistrictThanaRelationshipId", c => c.Int());
            CreateIndex("dbo.Thanas", "DistrictThanaRelationship_DistrictThanaRelationshipId");
            AddForeignKey("dbo.Thanas", "DistrictThanaRelationship_DistrictThanaRelationshipId", "dbo.DistrictThanaRelationships", "DistrictThanaRelationshipId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thanas", "DistrictThanaRelationship_DistrictThanaRelationshipId", "dbo.DistrictThanaRelationships");
            DropForeignKey("dbo.DistrictThanaRelationships", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Thanas", new[] { "DistrictThanaRelationship_DistrictThanaRelationshipId" });
            DropIndex("dbo.DistrictThanaRelationships", new[] { "DistrictId" });
            DropColumn("dbo.Thanas", "DistrictThanaRelationship_DistrictThanaRelationshipId");
            DropTable("dbo.DistrictThanaRelationships");
        }
    }
}
