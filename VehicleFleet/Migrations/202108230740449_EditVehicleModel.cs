namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditVehicleModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "EngineVolume", c => c.Single(nullable: false));
            AddColumn("dbo.Vehicles", "NewCarCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "NewCarCost");
            DropColumn("dbo.Vehicles", "EngineVolume");
        }
    }
}
