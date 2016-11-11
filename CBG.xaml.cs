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
            btnaddCust.Visibility = Visibility.Hidden;
            lblProperty1.Visibility = Visibility.Hidden;
            lblProperty2.Visibility = Visibility.Hidden;
            lblProperty3.Visibility = Visibility.Hidden;
            txtCBG1.Visibility = Visibility.Hidden;
            txtCBG2.Visibility = Visibility.Hidden;
            txtCBG3.Visibility = Visibility.Hidden;
        }

        private void btnAddCust_Click(object sender, RoutedEventArgs e)
        {
            Customer cust1 = new Customer();
            btnaddCust.Visibility = Visibility.Visible;
            lblProperty1.Visibility = Visibility.Visible;
            lblProperty2.Visibility = Visibility.Visible;
            lblProperty3.Visibility = Visibility.Visible;
            lblCBG.Visibility = Visibility.Visible;
            lblCBG.Content = "Add a Customer:";
            lblProperty1.Content = "First Name:";
            lblProperty2.Content = "Last Name:";
            lblProperty3.Content = "Address:";
            txtCBG1.Visibility = Visibility.Visible;
            txtCBG2.Visibility = Visibility.Visible;
            txtCBG3.Visibility = Visibility.Visible;
        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            Booking book1 = new Booking();
            btnaddCust.Visibility = Visibility.Visible;
            lblProperty1.Visibility = Visibility.Visible;
            lblProperty2.Visibility = Visibility.Visible;
            lblCBG.Visibility = Visibility.Visible;
            lblCBG.Content = "Add a Booking:";
            lblProperty1.Content = "Arrival Date:";
            lblProperty2.Content = "Departure Date:";
            lblProperty3.Visibility = Visibility.Hidden;
            txtCBG1.Visibility = Visibility.Visible;
            txtCBG2.Visibility = Visibility.Visible;
            txtCBG3.Visibility = Visibility.Hidden;
        }

        private void btnAddGuest_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnaddCust_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
