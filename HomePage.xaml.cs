using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Midterm
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        int superUser = 0;
        CustMethod one = new CustMethod();
        List<Customer> customers = new List<Customer>();
        
        
        public MainPage(int super /*List<Airlines> airlineList, List<Customer> custList, List<Flights> flightList, List<Passenger> passList*/)
        {
            InitializeComponent();
            superUser = super;
            customers = one.LoadCustomer(customers);





        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {


            CustomerPage customer = new CustomerPage(superUser);
            customer.Show();
             this.Close();

        }

        private void Flight_click(object sender, RoutedEventArgs e)
        {
            FlightsPage flightsPage = new FlightsPage(superUser);
            flightsPage.Show();
            this.Close();

        }

        private void Airline_click(object sender, RoutedEventArgs e)
        {
            AirlinesPage AirlinePage = new AirlinesPage(superUser);
            AirlinePage.Show();
            this.Close();

        }

        private void Passengers_click(object sender, RoutedEventArgs e)
        {
            PassengersPage passengers = new PassengersPage(superUser);
            passengers.Show();
            this.Close();
        }
    }
}
