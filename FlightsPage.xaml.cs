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
    /// Interaction logic for FlightsPage.xaml
    /// </summary>
    public partial class FlightsPage : Window
    {
        FlightsMethods flightsMethods = new FlightsMethods();
        List<Flights> flightList = new List<Flights>();
        AirlineMethods airlineMethods = new AirlineMethods();
        List<Airlines> airlineList = new List<Airlines>();
        
        



        int superUser = 0;
        public FlightsPage(int super)
        {
            InitializeComponent();
            flightList = flightsMethods.LoadFlights(flightList);
            airlineList = airlineMethods.LoadAirline(airlineList);
            superUser = super;

            var flight = from flights in flightList
                         select flights.Id;
            
            fname.DataContext = flight;

        }
        private void fname_selection(object sender, SelectionChangedEventArgs e)
        {
            int indexair = 0;
            int index = fname.SelectedIndex;
            var selectedFlight = from flights in flightList
                               where flights.Id == index
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

        private void Insert_Clicekd(object sender, RoutedEventArgs e)
        {
            if (superUser == 0)
            {
                MessageBox.Show("Please Log in With Super User", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int airlinid = Int32.Parse(txtairlineid.Text);
                if (airlineList.Count() > airlinid)
                {
                    double airtime = double.Parse(txttime.Text);
                    if (txtdeparture.Text == "" || txtdestination.Text == "" ||
                    txtdate.Text == "" || txttime.Text == "" || txtairlineid.Text == "")
                    {
                        MessageBox.Show("Please Fill Out all the Fild ", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBoxResult mr = MessageBox.Show("Do you want to Add Flight", "Confirm", MessageBoxButton.YesNo,
                         MessageBoxImage.Question);


                        if (mr == MessageBoxResult.Yes)
                        {
                            flightList.Add(new Flights(flightList.Count, airlinid,
                                    txtdeparture.Text, txtdestination.Text,
                                    txtdate.Text, airtime));

                            var flights = from flight in flightList
                                          select flight.Id;

                            fname.DataContext = flights;
                        }

                    }
                }
                else {

                    MessageBox.Show("Please Enter the Airline ID from the Airline List", "Error",
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
                int airlinid = Int32.Parse(txtairlineid.Text);
                if (airlineList.Count() > airlinid) 
                {

                    double airtime = double.Parse(txttime.Text);
                    if (txtdeparture.Text == "" || txtdestination.Text == "" ||
                    txtdate.Text == "" || txttime.Text == "" || txtairlineid.Text == "") {

                        MessageBox.Show("Please Fill Out all the Fild ", "Error",
                           MessageBoxButton.OK, MessageBoxImage.Error);


                    }

                    else
                    {
                        MessageBoxResult mr = MessageBox.Show("Do you want to Update Flight", "Confirm", MessageBoxButton.YesNo,
                         MessageBoxImage.Question);


                        if (mr == MessageBoxResult.Yes)
                        {

                            Flights flight = new Flights(fname.SelectedIndex, airlinid,
                                    txtdeparture.Text, txtdestination.Text,
                                    txtdate.Text, airtime);

                            flightList[fname.SelectedIndex] = flight;

                            var flights = from flyt in flightList
                                       select flyt.Id;

                            fname.DataContext = flights;

                        }
                    }
                }
                else
                {

                    MessageBox.Show("Please Enter the Airline ID from the Airline List", "Error",
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

                flightList.RemoveAt(fname.SelectedIndex);

                var flights = from flyt in flightList
                              select flyt.Id;

                fname.DataContext = flights;

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
