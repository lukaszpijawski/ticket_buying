namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePlaceToSeat : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "PlaceToSeat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "PlaceToSeat", c => c.Int(nullable: false));
        }
    }
}
