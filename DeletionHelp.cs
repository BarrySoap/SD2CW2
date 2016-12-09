using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    class DeletionHelp
    {
        string[] custLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Customer Records.txt");
        string[] bookLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");

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
    }
}
