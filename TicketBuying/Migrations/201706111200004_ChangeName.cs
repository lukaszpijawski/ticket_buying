namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Buyers SET Name = 'Katarzyna Ma³a' WHERE BuyerId = 2");
        }
        
        public override void Down()
        {
        }
    }
}
