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

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Represents the main hub of the program, allows access to each GUI.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddCBG_Click(object sender, RoutedEventArgs e)
        {
            CBG cuboguest = new CBG();                                      // Allows access to the window for creating
            cuboguest.Show();                                               // customers, bookings and guests.
        }

        private void btnExtras_Click(object sender, RoutedEventArgs e)
        {
            ExtrasPrompt extra = new ExtrasPrompt();                        // Allows access to the window for adding
            extra.Show();                                                   // extras to a booking.
        }

        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice inv = new Invoice();                                    // Allows access to the invoice for a booking.
            inv.Show();
        }

        private void btnDelCustomer_Click(object sender, RoutedEventArgs e)
        {
            DeleteCustomer del1 = new DeleteCustomer();                     // Allows access to the window for deleting a customer.
            del1.Show();
        }

        private void btnDelBooking_Click(object sender, RoutedEventArgs e)
        {
            DeleteBooking delbook1 = new DeleteBooking();                   // Allows access to the window for deleting a booking.
            delbook1.Show();
        }

        private void btnAmendCBG_Click(object sender, RoutedEventArgs e)
        {
            AmendCBG amend1 = new AmendCBG();                               // Allows access to the window for amending customers, bookings and guests.
            amend1.Show();
        }
    }
}
