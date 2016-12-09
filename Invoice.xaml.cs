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

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains logic for displaying an invoice.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    public partial class Invoice : Window
    {
        //******* Initialise objects for getting costs record. ******/
        Customer cust1 = new Customer();
        Booking book1 = Booking.Instance;
        Guests guest1 = new Guests();
        Extras extra1 = new Extras();
        //***********************************************************/

        //** Initialise variables containing dietary info and totalCost/Days **/
        private string dietaryResq;
        private string breakfastResq;
        private string driverName;
        private double totalCost = 50;
        private double totalDays = 0;
        //***********************************************************/

        public Invoice()
        {
            InitializeComponent();
        }

        //** This method is used to separate the evening meals dietary info **/
        //**                from the rest of the line.                      **/
        public string separateEVE(string s)
        {
            int dexOfCom = s.IndexOf(", BK:");
            if (dexOfCom > 0)
            {
                return s.Substring(0, dexOfCom);
            }
            return "";
        }
        //***********************************************************/

        //** This method is used to separate the breakfast dietary info **/
        //**                from the rest of the line.                  **/
        public string separateBK(string s)
        {
            int dexOfCom = s.IndexOf(", DN:");
            if (dexOfCom > 0)
            {
                return s.Substring(0, dexOfCom);
            }
            return "";
        }
        //***********************************************************/

        //** This method is used to separate the driver name **/
        //**           from the rest of the line.            **/
        public string separateDN(string s)
        {
            int dexOfCom = s.IndexOf(", " + totalDays);
            if (dexOfCom > 0)
            {
                return s.Substring(0, dexOfCom);
            }
            return "";
        }
        //***********************************************************/

        //******** This method will calculate the total cost of a booking by reading multiple files. **********/
        public void getCosts()
        {
            //************************* Initialise variables for storing file contents. ***********************/
            string[] bookLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");
            string[] guestLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Guest Records.txt");
            string[] extrasLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Extras Records.txt");
            //*************************************************************************************************/

            //* Create variables for storing arrival/departure dates.*/
            DateTime arrivalDate;
            DateTime departureDate;
            //********************************************************/

            string[] words;         // This variable is used to store a line temporarily.

            foreach (string line in bookLines)                                                  // Recursively check each line of the booking records file,
            {
                if (line.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))       // when the correct record is found,
                {
                    words = line.Split(' ');                                                    // split the line into separate words.
                    arrivalDate = DateTime.Parse(words[4]);                                     // Parse the 4th word (arrival date) to a DateTime
                    departureDate = DateTime.Parse(words[6]);                                   // Parse the 6th word (departure date) to a DateTime
                    totalDays = (departureDate - arrivalDate).TotalDays;                        // Calculate the total days from both dates.
                }
            }

            totalCost = totalCost * totalDays;

            foreach (string line in guestLines)
            {
                if (line.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))
                {
                    words = line.Split(' ');
                    if (int.Parse(words[7]) < 18)                                               // If the guests' age is less than 18,
                    {
                        totalCost = totalCost + (30 * totalDays);                               // the cost per day is only £30.
                    } else                                                                      // If the age is over 18,
                    {
                        totalCost = totalCost + (50 * totalDays);                               // The cost per day is £50.
                    }
                }
            }

            foreach (string line in extrasLines)
            {
                if (line.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))
                {
                    words = line.Split(' ');
                    totalCost = totalCost + (50 * int.Parse(words[words.Length - 1]));          // Multiply the basic cost of car hire by the amount of days booked (always last value).

                    if (line.Contains("EVE:"))                                                  // check for the identifier for evening meals.
                    {
                        totalCost = totalCost + 15 * totalDays;                                 // Multiply by the amount of days booked in.
                        dietaryResq = separateEVE(line).Replace("-For Booking Reference: " + txtBRefNumber.Text + "- EVE:", "");        // Call on the method to separate the evening meals
                    }                                                                                                                   // dietary info from the rest of the line.
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
            string contents = File.ReadAllText(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");             // Store the content of the file in a variable.
            getCosts();                                                                                                 // Calculate the total booking costs.
            if (contents.Contains("-For Booking Reference: " + txtBRefNumber.Text + "-"))                               // If the booking record exists,
            {
                if (txtBRefNumber.Text != "" && Double.TryParse(txtBRefNumber.Text, out temp))                          // and the reference number is valid,
                {
                    lblInvoice.Content = "Overall booking cost: " + totalCost.ToString() + "\n";                        // show the total cost,
                    lblInvoice.Content += "Breakfast Dietary Requirements: " + "\n" + breakfastResq + "\n";             // breakfast dietary info,
                    lblInvoice.Content += "Evening Meals Dietary Requirements: " + "\n" + dietaryResq + "\n";           // evening meals dietary info,
                    lblInvoice.Content += "Driver Name: " + "\n" + driverName + "\n";                                   // and driver name.

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
