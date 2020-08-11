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
    /// Interaction logic for AirlinesPage.xaml
    /// </summary>
    public partial class AirlinesPage : Window


    {

        AirlineMethods airlineMethods = new AirlineMethods();
        List<Airlines> airlineList = new List<Airlines>();
        int superUser = 0;
        string food = "";
        public AirlinesPage(int sup)
        {
            InitializeComponent();
            airlineList = airlineMethods.LoadAirline(airlineList);

            superUser = sup;
            var airline = from air in airlineList
                          select air.Name;

            fname.DataContext = airline;
        }
        private void fname_selection(object sender, SelectionChangedEventArgs e)
        {

            int index = fname.SelectedIndex;
            var selectedAirline = from air in airlineList
                                  where air.Id == index
                                  select air;
            foreach (var air in selectedAirline)
            {

                txtname.Text = air.Name;
                txtplane.Text = air.Airplane;
                int seat = air.SeataAvailable;
                string seats = "";
                txtseat.Text = seat.ToString(seats);
                txtmeal.Text = air.MealAvailable;
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (superUser == 0)
            {
                MessageBox.Show("Please Log in With Super User", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                if (txtname.Text == "" || txtplane.Text == "" ||
               txtseat.Text == "" || txtmeal.Text == "" || food == "")
                {

                    MessageBox.Show("Please Fill Out all the Fild ", "Error",
                       MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    MessageBoxResult mr = MessageBox.Show("Dou wnat to Add airline", "Confirm", MessageBoxButton.YesNo,
                     MessageBoxImage.Question);


                    if (mr == MessageBoxResult.Yes)
                    {

                        int airliseat = Int32.Parse(txtseat.Text);
                        airlineList.Add(new Airlines(airlineList.Count, txtname.Text,
                                txtplane.Text, airliseat, food));

                        var air = from airline in airlineList
                                  select airline.Name;

                        fname.DataContext = air;
                    }

                }



            }
        }

        private void rdo1_Checked(object sender, RoutedEventArgs e)
        {
            food = Pasta.Name;
        }
        private void rdo2_Checked(object sender, RoutedEventArgs e)
        {
            food = Chiken.Name; ;
        }
        private void rdo3_Checked(object sender, RoutedEventArgs e)
        {
            food = Sushi.Name;
        }
        private void rdo4_Checked(object sender, RoutedEventArgs e)
        {
            food = Salad.Name;
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


                int airliseat = Int32.Parse(txtseat.Text);
                if (txtname.Text == "" || txtplane.Text == "" ||
           txtseat.Text == "" || txtmeal.Text == "" || food == "")
                {

                    MessageBox.Show("Please Fill Out all the Fild ", "Error",
                       MessageBoxButton.OK, MessageBoxImage.Error);


                }

                else
                {
                    MessageBoxResult mr = MessageBox.Show("Do you want to Update Airline", "Confirm", MessageBoxButton.YesNo,
                     MessageBoxImage.Question);


                    if (mr == MessageBoxResult.Yes)
                    {

                        Airlines airline = new Airlines(fname.SelectedIndex,
                                 txtname.Text, txtplane.Text,
                                 airliseat, food);

                        airlineList[fname.SelectedIndex] = airline;

                        var air = from airlinelist in airlineList
                                  select airlinelist.Name;

                        fname.DataContext = air;

                    }
                }
            }

        }

        private void Delet_Clicked(object sender, RoutedEventArgs e)
        {
            if (superUser == 0)
            {
                MessageBox.Show("Please Log in With Super User", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

            }

            MessageBoxResult mr = MessageBox.Show("Do you want to Delet Airline", "Confirm", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);


            if (mr == MessageBoxResult.Yes)
            {

                airlineList.RemoveAt(fname.SelectedIndex);

                var air = from airlinelist in airlineList
                          select airlinelist.Name;

                fname.DataContext = air;


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
