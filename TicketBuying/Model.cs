using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicketBuying
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }                                      
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public int TicketImageId { get; set; }
        public int NumberOfFreePlaces { get; set; }
        public decimal Price { get; set; }
        public virtual TicketImage TicketImage { get; set; }
    }

    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }
        public string Name { get; set; }                
    }

    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int BuyerId { get; set; }
        public int EventId { get; set; }
        public int PaymentProcessorId { get; set; }
        public virtual PaymentProcessor PaymentProcessor { get; set; }
        public virtual Buyer Buyer { get; set; }
        public virtual Event Event { get; set; }
    }

    public class TicketImage
    {
        [Key]
        public int TicketImageId { get; set; }
        public byte[] Image { get; set; }
    }

    public class PaymentProcessor
    {
        public int PaymentProcessorId { get; set; }
        public string Name { get; set; }
    }

    public class TicketContext : DbContext
    {
        public TicketContext()
            : base("name=TicketContext")
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<TicketImage> TicketImages { get; set; }
        public DbSet<PaymentProcessor> PaymentProcessors { get; set; }
    }
}