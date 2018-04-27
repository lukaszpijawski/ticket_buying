namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        BuyerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PaymentProcessorId = c.Int(nullable: false),
                        Something = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuyerId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Place = c.String(),
                        TicketImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.PaymentProcessors",
                c => new
                    {
                        PaymentProcessorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PaymentProcessorId);
            
            CreateTable(
                "dbo.TicketImages",
                c => new
                    {
                        TicketImageId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.TicketImageId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        BuyerId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        PlaceToSeat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketImages");
            DropTable("dbo.PaymentProcessors");
            DropTable("dbo.Events");
            DropTable("dbo.Buyers");
        }
    }
}
