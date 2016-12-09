using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CW2
{
    /// <summary>
    /// Interaction logic for DeleteBooking.xaml
    /// </summary>
    public partial class DeleteBooking : Window
    {
        private string bookingPath = @"D:\Coursework 2\Coursework2\Records\Booking Records.txt";
        string[] bookLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");
        string contents = File.ReadAllText(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");

        public DeleteBooking()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (contents.Contains("-For Booking Reference: " + txtReferenceNumber.Text + "-"))
            {
                using (StreamWriter sw = new StreamWriter(bookingPath))
                {
                    foreach (string line in bookLines)
                    {
                        if (!line.Contains("-For Booking Reference: " + txtReferenceNumber.Text + "-"))
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Booking does not exist!");
            }
        }
    }
}
