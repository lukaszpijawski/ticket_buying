using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicketBuying
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class TicketInfo : INotifyPropertyChanged
        {
            private string eventName;
            public string EventName
            {
                get
                {
                    return eventName;
                }
                set
                {
                    eventName = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("EventName"));
                    }
                }
            }
            private string eventDate;
            public string EventDate
            {
                get
                {
                    return eventDate;
                }
                set
                {
                    eventDate = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("EventDate"));
                    }
                }
            }
            private string eventPlace;
            public string EventPlace
            {
                get
                {
                    return eventPlace;
                }
                set
                {
                    eventPlace = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("EventPlace"));
                    }
                }
            }
            private string eventPrice;
            public string EventPrice
            {
                get
                {
                    return eventPrice;
                }
                set
                {
                    eventPrice = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("EventPrice"));
                    }
                }
            }
            private string nameOfBuyer;
            public string NameOfBuyer
            {
                get
                {
                    return nameOfBuyer;
                }
                set
                {
                    nameOfBuyer = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("NameOfBuyer"));
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }

        private TicketInfo ticketInfo;

        public MainWindow()
        {
            InitializeComponent();
            ticketInfo = new TicketInfo();
            ProgramGrid.DataContext = ticketInfo;            

            using (var db = new TicketContext())
            {
                db.Database.Log = Console.WriteLine;
                var allEvents = (from item in db.Events
                                select item.Name).ToList();                
                var allPaymentProcessors = (from processor in db.PaymentProcessors
                                           select processor.Name).ToList();                
                AvailableEvents.ItemsSource = allEvents;
                AvailablePaymentProcessors.ItemsSource = allPaymentProcessors;
            }            
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public BitmapImage ByteArrayToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public void TestLoadingMethods(TicketContext db)
        {
            var lazyLoading = db.Buyers;
            var eagerLoading = db.Buyers.Select(z => new
            {
                Nazwisko = z.Name,
                Id = z.BuyerId,                
            }).ToList();

            foreach (var item in lazyLoading)
            {
                Console.WriteLine(item.Name + " ma id: " + item.BuyerId);
            }

            foreach (var item in eagerLoading)
            {
                Console.WriteLine(item.Nazwisko + " ma id: " + item.Id);
            }
        }       

        private void AvailableEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new TicketContext())
            {
                var places = (from item in db.Events
                             where item.Name == AvailableEvents.SelectedItem.ToString()
                             select item).ToList();                
                NumberOfAvailablePlaces.Text = places[0].NumberOfFreePlaces.ToString();
                EventPrice.Text = ticketInfo.EventPrice = places[0].Price.ToString();                
                ticketInfo.EventName = places[0].Name;
                ticketInfo.EventDate = places[0].Date.ToShortDateString().ToString();
                ticketInfo.EventPlace = places[0].Place;
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            if (FullName.Text == String.Empty)
            {
                MessageBox.Show("Proszę wpisać swoje dane");
            }
            else if (AvailableEvents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Proszę wybrać wydarzenie");
            }
            else if (AvailablePaymentProcessors.SelectedItems.Count == 0)
            {
                MessageBox.Show("Proszę wybrać procesor płatniczy");
            }
            else
            {
                using (var db = new TicketContext())
                {
                    var events = db.Events.Select(item => new
                    {
                        item.Name,
                        item.Place,
                        item.Date,
                        item.NumberOfFreePlaces,
                        item.TicketImageId,
                        item.EventId,
                        item.Price
                    }).ToList();                    

                    var chosenEvent = (from item in events
                                 where item.Name == AvailableEvents.SelectedItem.ToString()
                                 select item).ToList();
                    
                    int imageId = chosenEvent[0].TicketImageId;
                    var imageFromChosenEvent = (from image in db.TicketImages
                                 where image.TicketImageId == imageId
                                 select image).ToList();
                    
                    int numberOfPlaces = chosenEvent[0].NumberOfFreePlaces;
                    if (numberOfPlaces == 0)
                    {
                        MessageBox.Show("Niestety nie ma wolnych miejsc na to wydarzenie");
                    }
                    else
                    {                        
                        var buyer = (db.Buyers.Where(item => item.Name == FullName.Text)).ToList();
                        int buyerId;
                        if (buyer.Count == 0)
                        {
                            Buyer newBuyer = new Buyer
                            {
                                Name = FullName.Text                                
                            };
                            buyerId = newBuyer.BuyerId;
                            db.Buyers.Add(newBuyer);
                        }
                        else
                        {
                            buyerId = buyer[0].BuyerId;
                        }
                        db.Tickets.Add(
                            new Ticket
                            {
                                BuyerId = buyerId,
                                EventId = chosenEvent[0].EventId,
                                PaymentProcessorId = Int32.Parse((from processor in db.PaymentProcessors
                                                                  where AvailablePaymentProcessors.SelectedItem.ToString() == processor.Name
                                                                  select processor.PaymentProcessorId).ToList()[0].ToString())
                            });
                        var chosenEventChanger = (from item in db.Events
                                                 where item.Name == AvailableEvents.SelectedItem.ToString()
                                                 select item).ToList();
                        int decreasedNumberOfFreePlaces = --chosenEventChanger[0].NumberOfFreePlaces;                       
                        db.SaveChanges();
                        MessageBox.Show("Zakup biletu zakończony powodzeniem!");                        
                        TicketFullName.Text = FullName.Text;                        
                        TicketImage.Source = ByteArrayToImage(imageFromChosenEvent[0].Image);
                        NumberOfAvailablePlaces.Text = decreasedNumberOfFreePlaces.ToString();
                    }
                }
            }
        }
    }   
}