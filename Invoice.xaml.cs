using System;
using System.IO;
using System.Text.RegularExpressions;
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
        Customer cust1 = new Customer();
        Booking book1 = new Booking();
        Guests guest1 = new Guests();
        Extras extra1 = new Extras();
        private double totalCost;

        public Invoice()
        {
            InitializeComponent();
        }

        public void getCosts()
        {
            string[] bookLines = File.ReadAllLines(@"F:\Coursework 2\Coursework2\Records\Booking Records.txt");
            string[] guestLines = File.ReadAllLines(@"F:\Coursework 2\Coursework2\Records\Guest Records.txt");
            DateTime arrivalDate;
            DateTime departureDate;
            string[] words;
            double totalDays = 50;

            foreach (string line in bookLines)
            {
                if (line.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))
                {
                    words = line.Split(' ');
                    arrivalDate = DateTime.Parse(words[4]);
                    departureDate = DateTime.Parse(words[6]);
                    totalDays = (departureDate - arrivalDate).TotalDays;
                }
            }

            foreach (string line in guestLines)
            {
                if (line.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))
                {
                    words = line.Split(' ');
                    if (int.Parse(words[7]) < 18)
                    {
                        totalCost = totalCost + (30 * totalDays);
                    } else
                    {
                        totalCost = totalCost + (50 * totalDays);
                    }
                }
            }


        }
        
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            getCosts();
            if (txtBRefNumber.Text != "" && Double.TryParse(txtBRefNumber.Text, out temp))
            {
                lblInvoice.Content = "Overall booking cost: " + 4;
            } else
            {
                MessageBox.Show("The booking reference number must be valid!");
            }
        }
    }
}
