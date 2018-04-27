namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVirtualfields : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Buyers", "PaymentProcessorId");
            CreateIndex("dbo.Events", "TicketImageId");
            CreateIndex("dbo.Tickets", "BuyerId");
            CreateIndex("dbo.Tickets", "EventId");            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buyers", "Something", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropForeignKey("dbo.Tickets", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Events", "TicketImageId", "dbo.TicketImages");
            DropForeignKey("dbo.Buyers", "PaymentProcessorId", "dbo.PaymentProcessors");
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.Tickets", new[] { "BuyerId" });
            DropIndex("dbo.Events", new[] { "TicketImageId" });
            DropIndex("dbo.Buyers", new[] { "PaymentProcessorId" });
        }
    }
}
