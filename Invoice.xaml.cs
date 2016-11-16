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
    public partial class Invoice : Window
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            double temp;

            if (txtBRefNumber.Text != "" && Double.TryParse(txtBRefNumber.Text, out temp))
            {
                lblInvoice.Content = "Overall booking cost: ";
            } else
            {
                MessageBox.Show("The booking reference number must be valid!");
            }
        }
    }
}
