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
        Booking book1 = Booking.Instance;
        Guests guest1 = new Guests();
        Extras extra1 = new Extras();
        string dietaryResq;
        string breakfastResq;
        string driverName;
        private double totalCost = 50;
        double totalDays = 0;

        public Invoice()
        {
            InitializeComponent();
        }

        public string separateEVE(string s)
        {
            int dexOfCom = s.IndexOf(", BK:");
            if (dexOfCom > 0)
            {
                return s.Substring(0, dexOfCom);
            }
            return "";
        }

        public string separateBK(string s)
        {
            int dexOfCom = s.IndexOf(", DN:");
            if (dexOfCom > 0)
            {
                return s.Substring(0, dexOfCom);
            }
            return "";
        }

        public string separateDN(string s)
        {
            int dexOfCom = s.IndexOf(", " + totalDays);
            if (dexOfCom > 0)
            {
                return s.Substring(0, dexOfCom);
            }
            return "";
        }

        public void getCosts()
        {
            string[] bookLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");
            string[] guestLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Guest Records.txt");
            string[] extrasLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Extras Records.txt");
            DateTime arrivalDate;
            DateTime departureDate;
            string[] words;

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

            totalCost = totalCost * totalDays;

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

            foreach (string line in extrasLines)
            {
                if (line.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))
                {
                    words = line.Split(' ');
                    totalCost = totalCost + (50 * int.Parse(words[words.Length - 1]));

                    if (line.Contains("EVE:"))
                    {
                        totalCost = totalCost + 15 * totalDays;
                        dietaryResq = separateEVE(line).Replace("-For Booking Reference: " + txtBRefNumber.Text + "- EVE:", "");
                    }
                    if (line.Contains("BK:"))
                    {
                        totalCost = totalCost + 5 * totalDays;
                        breakfastResq = separateBK(line).Replace("-For Booking Reference: " + txtBRefNumber.Text + "- EVE:" + dietaryResq + ", BK:", "");
                    }
                    if (line.Contains("DN:"))
                    {
                        driverName = separateDN(line).Replace("-For Booking Reference: " + txtBRefNumber.Text + "- EVE:" + dietaryResq + ", BK:" + breakfastResq + ", DN:", "");
                    }
                }
            }
        }
        
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            string contents = File.ReadAllText(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");
            getCosts();
            if (contents.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))
            {
                if (txtBRefNumber.Text != "" && Double.TryParse(txtBRefNumber.Text, out temp))
                {
                    lblInvoice.Content = "Overall booking cost: " + totalCost.ToString() + "\n";
                    lblInvoice.Content += "Breakfast Dietary Requirements: " + "\n" + breakfastResq + "\n";
                    lblInvoice.Content += "Evening Meals Dietary Requirements: " + "\n" + dietaryResq + "\n";
                    lblInvoice.Content += "Driver Name: " + "\n" + driverName + "\n";

                } else
                {
                    MessageBox.Show("Booking reference number must be valid!");
                }
            }
            else
            {
                MessageBox.Show("Booking does not exist!");
            }
             
        }
    }
}
