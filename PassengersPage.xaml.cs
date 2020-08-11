using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for PassengersPage.xaml
    /// </summary>
    public partial class PassengersPage : Window
    {

        int superUser = 0;
        List<Passenger> passengers = new List<Passenger>();
        PasssengerMethods passengerMethods = new PasssengerMethods();
        CustMethod one = new CustMethod();
        List<Customer> customers = new List<Customer>();
        FlightsMethods flightsMethods = new FlightsMethods();
        List<Flights> flightList = new List<Flights>();
        AirlineMethods airlineMethods = new AirlineMethods();
        List<Airlines> airlineList = new List<Airlines>();


        int index = 0;
        int indexpass = 0;
        public PassengersPage(int sup)
        {
            InitializeComponent();

            superUser = sup;
            airlineList = airlineMethods.LoadAirline(airlineList);
            passengers = passengerMethods.LoadPassenger(passengers);
            var passeng = from passen in passengers
                          select passen.Id;

            fname.DataContext = passeng;

            customers = one.LoadCustomer(customers);
            var name = from pass in customers
                       select pass.Name;

            aname.DataContext = name;

            flightList = flightsMethods.LoadFlights(flightList);


            var flight = from flights in flightList
                         select flights.Id;

            bname.DataContext = flight;

        }
        private void aname_selection(object sender, SelectionChangedEventArgs e)
        {
            index = aname.SelectedIndex;
            var selectedcust = from cust in customers
                               where cust.Id == index
                               select cust;
            foreach (var cust in selectedcust)
            {
                txtnme.Text = cust.Name;
                txtaddress.Text = cust.Address;
                txtphone.Text = cust.Phone;
                txtemail.Text = cust.Email;
            }
        }
        private void bname_selection(object sender, SelectionChangedEventArgs e)
        {
            int indexair = 0;

            int i = bname.SelectedIndex;
            var selectedFlight = from flights in flightList
                                 where flights.Id == i
                                 select flights;
            foreach (var flights in selectedFlight)
            {
                indexair = flights.Airlineid;
                txtdeparture.Text = flights.Departurecity;
                txtdestination.Text = flights.Destinationcity;
                txtdate.Text = flights.Departuredate;
                double one = flights.Flighttime;
                string time = "";
                txttime.Text = one.ToString(time);
            }
            var selectedAirline = from airliens in airlineList
                                  where airliens.Id == indexair
                                  select airliens;
            foreach (var air in selectedAirline)
            {

                txtairline.Text = air.Name;
                int id = air.Id;
                string ids = "";
                txtairlineid.Text = id.ToString(ids);
            }

        }
        private void fname_selection(object sender, SelectionChangedEventArgs e)
        {

            indexpass = fname.SelectedIndex;
            var selectedpass = from passengerlist in passengers
                               where passengerlist.Id == indexpass
                               select passengerlist;

            foreach (var pass in selectedpass)
            {

                int custid = pass.CustomerId;
                string cid = "";
                txtid.Text = custid.ToString(cid);
                int fid = pass.FlightId;
                string fliid = "";
                txtflight.Text = fid.ToString(fliid);


                var selectedcust = from cust in customers
                                   where cust.Id == pass.CustomerId
                                   select cust;
                foreach (var cust in selectedcust)
                {
                    txtname.Text = cust.Name;

                }
            }


        }

        private void Insert_Clicekd(object sender, RoutedEventArgs e)
        {
            if (superUser == 0)
            {
                MessageBox.Show("Please Log in With Super User", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int flightid = Int32.Parse(txtflight.Text);
                int custid = Int32.Parse(txtid.Text);
                if (flightList.Count() > flightid || customers.Count() > custid)
                {

                    if (txtid.Text == "" || txtflight.Text == "")
                    {
                        MessageBox.Show("Please Fill out Flight id and Customer id ", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBoxResult mr = MessageBox.Show("Do you want to Add Passenger", "Confirm", MessageBoxButton.YesNo,
                         MessageBoxImage.Question);


                        if (mr == MessageBoxResult.Yes)
                        {
                            passengers.Add(new Passenger(customers.Count, custid, flightid));

                            var passeng = from passen in passengers
                                          select passen.Id;

                            fname.DataContext = passeng;
                        }

                    }
                }
                else
                {

                    MessageBox.Show("Please Fill out Flight id and Customer id ", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }

        }

        private void Update_Clicekd(object sender, RoutedEventArgs e)
        {
            if (superUser == 0)
            {
                MessageBox.Show("Please Log in With Super User", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int flightid = Int32.Parse(txtflight.Text);
                int custid = Int32.Parse(txtid.Text);
                if (flightList.Count() > flightid || customers.Count() > custid)
                {


                    if (txtid.Text == "" || txtflight.Text == "")
                    {

                        MessageBox.Show("Please Fill out Flight id and Customer id", "Error",
                           MessageBoxButton.OK, MessageBoxImage.Error);


                    }

                    else
                    {
                        MessageBoxResult mr = MessageBox.Show("Do you want to Update Passenger", "Confirm", MessageBoxButton.YesNo,
                         MessageBoxImage.Question);


                        if (mr == MessageBoxResult.Yes)
                        {

                            Passenger passeng
                                = new Passenger(customers.Count, custid, flightid);

                            passengers[fname.SelectedIndex] = passeng;

                            var pass = from passn in passengers
                                       select passn.Id;

                            fname.DataContext = pass;

                        }
                    }
                }
                else
                {

                    MessageBox.Show("Please Fill out Flight id and Customer id", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        private void Delet_Clicekd(object sender, RoutedEventArgs e)
        {

            if (superUser == 0)
            {
                MessageBox.Show("Please Log in With Super User", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

            }

            MessageBoxResult mr = MessageBox.Show("Do you want to Delet Coustomer", "Confirm", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);


            if (mr == MessageBoxResult.Yes)
            {

                passengers.RemoveAt(fname.SelectedIndex);

                var pass = from passn in passengers
                             select passn.Id;

                fname.DataContext = pass;

            }

        }

        private void Quit_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mr = MessageBox.Show("Do you want to close application", "Confirm", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);


            if (mr == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}

