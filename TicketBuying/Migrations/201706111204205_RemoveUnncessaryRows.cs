namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnncessaryRows : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from dbo.Buyers Where BuyerId > 3");
            Sql("Delete from dbo.Tickets Where TicketId > 3");
            Sql("Delete from dbo.Events Where EventId > 3");
            Sql("Delete from dbo.PaymentProcessors Where PaymentProcessorId > 3");
            Sql("Delete from dbo.TicketImages Where TicketImageId > 3");
        }
        
        public override void Down()
        {
        }
    }
}
