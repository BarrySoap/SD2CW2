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
using System.Windows.Shapes;

namespace CW2
{
    /// <summary>
    /// Interaction logic for CBG.xaml
    /// </summary>
    public partial class CBG : Window
    {
        public CBG()
        {
            InitializeComponent();
            hideAdditions();
        }

        public void hideAdditions()
        {
            lblCBG.Visibility = Visibility.Hidden;
            txtCBG1.Visibility = Visibility.Hidden;
            txtCBG2.Visibility = Visibility.Hidden;
            txtCBG3.Visibility = Visibility.Hidden;
        }

        private void btnAddCust_Click(object sender, RoutedEventArgs e)
        {
            Customer cust1 = new Customer();
            lblCBG.Visibility = Visibility.Visible;
            lblCBG.Content = "Add a Customer:";
            txtCBG1.Text = "First Name";
            txtCBG2.Text = "Last Name";
            txtCBG3.Text = "Address";
            txtCBG1.Visibility = Visibility.Visible;
            txtCBG2.Visibility = Visibility.Visible;
            txtCBG3.Visibility = Visibility.Visible;
        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            Booking book1 = new Booking();
            lblCBG.Visibility = Visibility.Visible;
            lblCBG.Content = "Add a Booking:";
            txtCBG1.Text = "Arrival Date";
            txtCBG2.Text = "Departure Date";
            txtCBG1.Visibility = Visibility.Visible;
            txtCBG2.Visibility = Visibility.Visible;
            txtCBG3.Visibility = Visibility.Hidden;
        }

        private void btnAddGuest_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
