namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovePriceFromTicketToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Tickets", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Events", "Price");
        }
    }
}
