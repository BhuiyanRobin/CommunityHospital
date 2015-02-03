namespace CommunityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thana : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Thanas",
                c => new
                    {
                        ThanaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ThanaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Thanas");
        }
    }
}
