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
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Window
    {

        int superUser = 0;
        
      CustMethod one = new CustMethod();
       List<Customer> customers = new List<Customer>();
        
        public CustomerPage(int sup)
        {
                       
            InitializeComponent();
            
            superUser = sup;
            customers = one.LoadCustomer(customers);

           

                var name = from pass in customers
                       select pass.Name;
           
            fname.DataContext = name;
           
        }

        private void fname_selection(object sender, SelectionChangedEventArgs e)
        {
            int index = fname.SelectedIndex;
            var selectedcust = from cust in customers
                               where cust.Id == index
                               select cust;
            foreach (var cust in selectedcust)
            {
                txtname.Text = cust.Name;
                txtaddress.Text = cust.Address;
                txtphone.Text = cust.Phone;
                txtemail.Text = cust.Email;
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

                if (txtname.Text == "" || txtaddress.Text == "" ||
                txtphone.Text == "" || txtemail.Text == "")
                {
                    MessageBox.Show("Please Fill Out all the Fild ", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBoxResult mr = MessageBox.Show("Dou wnat to Add Coustomer", "Confirm", MessageBoxButton.YesNo,
                     MessageBoxImage.Question);


                    if (mr == MessageBoxResult.Yes)
                    {
                        customers.Add(new Customer(customers.Count, txtname.Text,
                                txtaddress.Text, txtemail.Text,
                                txtphone.Text));

                        var cust = from customer in customers
                                   select customer.Name;

                        fname.DataContext = cust;
                    }
                    
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

                if (txtname.Text == "" || txtaddress.Text == "" ||
                txtphone.Text == "" || txtemail.Text == "")
                {
                    MessageBox.Show("Please Fill Out all the Fild ", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBoxResult mr = MessageBox.Show("Dou wnat to Update Coustomer", "Confirm", MessageBoxButton.YesNo,
                     MessageBoxImage.Question);


                    if (mr == MessageBoxResult.Yes)
                    {

                        Customer custom = new Customer(fname.SelectedIndex, txtname.Text,
                                txtaddress.Text, txtemail.Text,
                                txtphone.Text);

                        customers[fname.SelectedIndex] = custom;

                        var cust = from customer in customers
                                   select customer.Name;

                        fname.DataContext = cust;

                    }
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

                customers.RemoveAt(fname.SelectedIndex);

                var cust = from customer in customers
                           select customer.Name;

                fname.DataContext = cust;


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
