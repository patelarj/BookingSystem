using System;
using System.Collections.Generic;
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

namespace Midterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        LoginMethods log = new LoginMethods();
        List<LoginDetails> login = new List<LoginDetails>();
        Dictionary<string, string> logdict = new Dictionary<string, string>();
        
        


        public MainWindow()
        {
            InitializeComponent();
            
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            
            
           
            login = log.LodLogin(login);
            logdict = log.LogDictionary(logdict, login);
            int superuser = 0;
            string user = input.Text;
            string inputpass = pass.Password;
            bool super = log.ValSuper(user, login);
            if (super)
            {

                superuser = 1;

            }

            bool valid = log.ValLogin(user, inputpass, logdict);
          

            if (valid)
            {
                
                MainPage main = new MainPage(superuser );
                main.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Log in Details Wrong");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
