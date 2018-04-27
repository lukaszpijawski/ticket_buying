namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProcessorsFromBuyerToTicket1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Buyers", new[] { "PaymentProcessorId" });
            DropColumn("dbo.Buyers", "PaymentProcessorId");
            AddColumn("dbo.Tickets", "PaymentProcessorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "PaymentProcessorId");
            AddForeignKey("dbo.Tickets", "PaymentProcessorId", "dbo.PaymentProcessors", "PaymentProcessorId", cascadeDelete: true);
        }

        public override void Down()
        {
        }
    }
}
