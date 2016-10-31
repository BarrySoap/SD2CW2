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

namespace CW2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialiseObjects();
        }

        public void InitialiseObjects() 
        {
            Customer cust1 = new Customer();
            Booking book1 = new Booking();
            Guests guest1 = new Guests();
        }

        private void btnAddCBG_Click(object sender, RoutedEventArgs e)
        {
            CBG cuboguest = new CBG();
            cuboguest.Show();
        }

        private void btnExtras_Click(object sender, RoutedEventArgs e)
        {
            Extras extra = new Extras();
            extra.Show();
        }

        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAmendCBG_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
