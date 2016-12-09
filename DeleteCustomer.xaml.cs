using System;
using System.IO;
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

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains logic for deleting a customer, with the help of a facade class.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    public partial class DeleteCustomer : Window
    {
        public string customerPath = @"D:\Coursework 2\Coursework2\Records\Customer Records.txt";         // Initialise the path of the record file.

        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)                                   // When the 'submit' button is pressed,
        {
            Facade facade = new Facade();                                                                // Initialise a facade object,
            facade.deleteCustomer(double.Parse(txtReferenceNumber.Text));                                // then call on a method to delete a customer within the facade.
        }
    }
}
