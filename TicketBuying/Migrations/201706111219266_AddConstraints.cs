namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraints : DbMigration
    {
        public override void Up()
        {
            Sql("Alter table Buyers drop column Something");
            Sql("ALTER TABLE[dbo].[Tickets] ADD CONSTRAINT[TicketToEvent] FOREIGN KEY([EventId]) REFERENCES[dbo].[Events](EventId)");
            Sql("ALTER TABLE[dbo].[Tickets] ADD CONSTRAINT[TicketToBuyer] FOREIGN KEY([BuyerId]) REFERENCES[dbo].[Buyers](BuyerId)");
            Sql("ALTER TABLE[dbo].[Events] ADD CONSTRAINT[EventToTicketImage] FOREIGN KEY([TicketImageId]) REFERENCES[dbo].[TicketImages](TicketImageId)");
            Sql("ALTER TABLE[dbo].[Buyers] ADD CONSTRAINT[BuyerToPaymentProcessor] FOREIGN KEY([PaymentProcessorId]) REFERENCES[dbo].[PaymentProcessors] (PaymentProcessorId)");
        }    

    public override void Down()
        {
        }
    }
}
