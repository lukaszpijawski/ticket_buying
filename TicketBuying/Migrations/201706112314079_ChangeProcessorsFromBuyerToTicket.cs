namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProcessorsFromBuyerToTicket : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Buyers", "PaymentProcessorId", "dbo.PaymentProcessors");
            DropIndex("dbo.Buyers", new[] { "PaymentProcessorId" });
            DropColumn("dbo.Buyers", "PaymentProcessorId");
            AddColumn("dbo.Tickets", "PaymentProcessorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "PaymentProcessorId");
            AddForeignKey("dbo.Tickets", "PaymentProcessorId", "dbo.PaymentProcessors", "PaymentProcessorId", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.Buyers", "PaymentProcessorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "PaymentProcessorId", "dbo.PaymentProcessors");
            DropIndex("dbo.Tickets", new[] { "PaymentProcessorId" });
            DropColumn("dbo.Tickets", "PaymentProcessorId");
            CreateIndex("dbo.Buyers", "PaymentProcessorId");
            AddForeignKey("dbo.Buyers", "PaymentProcessorId", "dbo.PaymentProcessors", "PaymentProcessorId", cascadeDelete: true);
        }
    }
}
