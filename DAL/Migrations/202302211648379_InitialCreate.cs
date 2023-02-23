namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleMakeEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abrv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleModelEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abrv = c.String(),
                        MakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMakeEntity", t => t.MakeId, cascadeDelete: true)
                .Index(t => t.MakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModelEntity", "MakeId", "dbo.VehicleMakeEntity");
            DropIndex("dbo.VehicleModelEntity", new[] { "MakeId" });
            DropTable("dbo.VehicleModelEntity");
            DropTable("dbo.VehicleMakeEntity");
        }
    }
}
