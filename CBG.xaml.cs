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
        Guests guest1 = new Guests();
        Booking book1 = new Booking();
        Customer cust1 = new Customer();

        public CBG()
        {
            InitializeComponent();
            hideAdditions();
        }

        public void hideAdditions()
        {
            lblCBG.Visibility = Visibility.Hidden;
            btnaddCBG.Visibility = Visibility.Hidden;
            lblProperty1.Visibility = Visibility.Hidden;
            lblProperty2.Visibility = Visibility.Hidden;
            lblProperty3.Visibility = Visibility.Hidden;
            txtCBG1.Visibility = Visibility.Hidden;
            txtCBG2.Visibility = Visibility.Hidden;
            txtCBG3.Visibility = Visibility.Hidden;
        }

        private void btnAddCust_Click(object sender, RoutedEventArgs e)
        {
            btnaddCBG.Visibility = Visibility.Visible;
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
            btnaddCBG.Visibility = Visibility.Visible;
            lblProperty1.Visibility = Visibility.Visible;
            lblProperty2.Visibility = Visibility.Visible;
            lblCBG.Visibility = Visibility.Visible;
            lblCBG.Content = "Add a Booking:";
            lblProperty1.Content = "Arrival Date (dd/mm/yyyy):";
            lblProperty2.Content = "Departure Date (dd/mm/yyyy):";
            lblProperty3.Visibility = Visibility.Hidden;
            txtCBG1.Visibility = Visibility.Visible;
            txtCBG2.Visibility = Visibility.Visible;
            txtCBG3.Visibility = Visibility.Hidden;
        }

        private void btnAddGuest_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnaddCBG_Click_1(object sender, RoutedEventArgs e)
        {
            if (lblCBG.Content.ToString() == "Add a Customer:")
            {
                if (txtCBG1.Text != "" && txtCBG2.Text != "" && txtCBG3.Text != "")
                {
                    cust1.CustomerFirstName = txtCBG1.Text;
                    cust1.CustomerSecondName = txtCBG2.Text;
                    cust1.CustomerAddress = txtCBG3.Text;
                } else
                {
                    MessageBox.Show("The above fields must be valid/not blank!");
                }
            } 

            if (lblCBG.Content.ToString() == "Add a Booking:")
            {
                DateTime d;

                if (DateTime.TryParse(txtCBG1.Text, out d) && DateTime.TryParse(txtCBG2.Text, out d))
                {
                    book1.ArrivalDate = DateTime.Parse(txtCBG1.Text);
                    book1.DepartureDate = DateTime.Parse(txtCBG2.Text);
                } else
                {
                    MessageBox.Show("The arrival date and departure date boxes must be valid dates!");
                }
            }
        }
    }
}
