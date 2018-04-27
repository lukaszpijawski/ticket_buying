namespace TicketBuying.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Windows.Media.Imaging;

    internal sealed class Configuration : DbMigrationsConfiguration<TicketBuying.TicketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TicketBuying.TicketContext context)
        {
            //Bitmap image1 = new Bitmap(@"C:\Users\£ukasz\Documents\studia\II rok\Bazy danych\Zaliczenie\pi³ka.jpg");
            //Bitmap image2 = new Bitmap(@"C:\Users\£ukasz\Documents\studia\II rok\Bazy danych\Zaliczenie\bie¿nia.jpg");
            //Bitmap image3 = new Bitmap(@"C:\Users\£ukasz\Documents\studia\II rok\Bazy danych\Zaliczenie\rower.jpg");

            //MemoryStream ms1 = new MemoryStream();
            //MemoryStream ms2 = new MemoryStream();
            //MemoryStream ms3 = new MemoryStream();
            //image1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
            //image2.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
            //image3.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg);

            //context.TicketImages.AddOrUpdate(
            //        new TicketImage { Image = ms1.ToArray() },
            //        new TicketImage { Image = ms2.ToArray() },
            //        new TicketImage { Image = ms3.ToArray() }
            //    );
            //context.PaymentProcessors.AddOrUpdate(
            //        new PaymentProcessor { Name = "PayPal" },
            //        new PaymentProcessor { Name = "Payza" },
            //        new PaymentProcessor { Name = "PayU" }
            //    );
            //context.Buyers.AddOrUpdate(
            //        new Buyer { Name = "£ukasz Pijawski", PaymentProcessorId = 2 },
            //        new Buyer { Name = "Marek Stonoga", PaymentProcessorId = 1 },
            //        new Buyer { Name = "Ewelina Zielona", PaymentProcessorId = 3 }
            //    );
            //context.Events.AddOrUpdate(
            //        new Event { Name = "igrzyska", Place = "Wroc³aw", Date = DateTime.Parse("01-02-2017"), TicketImageId = 1 },
            //        new Event { Name = "mistrzostwa", Place = "Warszawa", Date = DateTime.Parse("05-06-2017"), TicketImageId = 2 },
            //        new Event { Name = "miting", Place = "Wroc³aw", Date = DateTime.ParseExact("21-04-2017", "dd-mm-yyyy", CultureInfo.InvariantCulture), TicketImageId = 3 }
            //    );
            //context.Tickets.AddOrUpdate(
            //        new Ticket { BuyerId = 1, PlaceToSeat = 6, EventId = 2 },
            //        new Ticket { BuyerId = 2, PlaceToSeat = 23, EventId = 1 },
            //        new Ticket { BuyerId = 3, PlaceToSeat = 65, EventId = 2 },
            //        new Ticket { BuyerId = 3, PlaceToSeat = 12, EventId = 3 }
            //    );
        }
    }
}
