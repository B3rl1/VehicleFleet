namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditVehicleModel2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "EngineVolume");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "EngineVolume", c => c.Double(nullable: false));
        }
    }
}
