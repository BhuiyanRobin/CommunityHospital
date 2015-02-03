namespace CommunityHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medicine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.String(),
                    })
                .PrimaryKey(t => t.MedicineId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicines");
        }
    }
}
