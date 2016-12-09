using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains methods for checking the existence of booking/customer records,
 *                as well as methods for deleting them respectively.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    class DeletionHelp
    {
        string[] custLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Customer Records.txt");         // Initialise the path of the customer file.
        string[] bookLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");          // Initialise the path of the booking file.

        //****************** This method checks whether a customer exists or not within the record file. *******/
        public void checkCustomerValidity(double custRefNumber)
        {
            string contents = File.ReadAllText(@"D:\Coursework 2\Coursework2\Records\Customer Records.txt");
            if (contents.Contains("-For Customer Reference: " + custRefNumber + "-"))
            {
                MessageBox.Show("Customer exists, commencing delete...");
            }
            else
            {
                MessageBox.Show("Customer does not exist.");
            }
        }
        //******************************************************************************************************/

        //****************** This method checks whether a booking exists or not within the record file. *******/
        public void checkBookingValidity(double bookRefNumber)
        {
            string contents = File.ReadAllText(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");
            if (contents.Contains("-For Booking Reference: " + bookRefNumber + "-"))
            {
                MessageBox.Show("Booking exists, commencing delete...");
            }
            else
            {
                MessageBox.Show("Booking does not exist.");
            }
        }
        //******************************************************************************************************/

        //*** This method will recursively check for a customer record, and then delete the appropriate one. ***/
        public void deleteCust(string path, double custRefNumber)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string line in custLines)
                {
                    if (!line.Contains("-For Customer Reference: " + custRefNumber + "-"))
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }
        //******************************************************************************************************/

        //**** This method will recursively check for a booking record, and then delete the appropriate one. ***/
        public void deleteBooking(string path, double bookRefNumber)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string line in bookLines)
                {
                    if (!line.Contains("-For Booking Reference: " + bookRefNumber + "-"))
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }
        //******************************************************************************************************/
    }
}
