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

namespace CW2
{
    /// <summary>
    /// Interaction logic for DeleteCustomer.xaml
    /// </summary>
    public partial class DeleteCustomer : Window
    {
        private string customerPath = @"D:\Coursework 2\Coursework2\Records\Customer Records.txt";
        string[] custLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Customer Records.txt");
        string contents = File.ReadAllText(@"D:\Coursework 2\Coursework2\Records\Customer Records.txt");

        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (contents.Contains("-For Customer Reference: " + txtReferenceNumber.Text + "-"))
            {
                using (StreamWriter sw = new StreamWriter(customerPath))
                {
                    foreach (string line in custLines)
                    {
                        if (!line.Contains("-For Customer Reference: " + txtReferenceNumber.Text + "-"))
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Customer does not exist!");
            }
        }
    }
}
