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

        public string getCosts()
        {
            string[] lines = File.ReadAllLines(@"F:\Coursework 2\Coursework2\Records\Booking Records.txt");
            foreach (string line in lines)
            {
                if (line.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))
                {
                    string[] words = line.Split(' ');
                    DateTime arrivalDate = DateTime.Parse(words[4]);
                    DateTime departureDate = DateTime.Parse(words[6]);
                    double totalDays = (departureDate - arrivalDate).TotalDays;
                    Console.WriteLine(totalDays);
                }
            }

            return book1.ArrivalDate.ToShortDateString();
        }

        public double calculateCosts()
        {
            totalCost += 50;
            totalCost = totalCost * (book1.DepartureDate - book1.ArrivalDate).TotalDays;
            if (guest1.GuestAge < 18)
            {
                totalCost = totalCost + 30;
            } else
            {
                totalCost = totalCost + 50;
            }

            return totalCost;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            getCosts();
            if (txtBRefNumber.Text != "" && Double.TryParse(txtBRefNumber.Text, out temp))
            {
                lblInvoice.Content = "Overall booking cost: " + calculateCosts();
            } else
            {
                MessageBox.Show("The booking reference number must be valid!");
            }
        }
    }
}
