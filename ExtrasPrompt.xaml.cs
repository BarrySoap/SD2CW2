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
    /// Interaction logic for ExtrasPrompt.xaml
    /// </summary>
    public partial class ExtrasPrompt : Window
    {
        private string extrasPath = @"D:\Coursework 2\Coursework2\Records\Extras Records.txt";

        public ExtrasPrompt()
        {
            InitializeComponent();
            if (!File.Exists(extrasPath))
            {
                using (StreamWriter sw = File.CreateText(extrasPath))
                {
                    sw.WriteLine("Evening Meals Dietary Requirements (EM), Breakfast Dietary Requirements (BF), Car Hire (CH)" + Environment.NewLine);
                }
            }
            hideLabelsButtons();
        }

        public void hideLabelsButtons()
        {
            lblEnterRef.Visibility = Visibility.Hidden;
            txtReturnRef.Visibility = Visibility.Hidden;
            btnSubmit.Visibility = Visibility.Hidden;
        }

        private void btnBookYes_Click(object sender, RoutedEventArgs e)
        {
            lblEnterRef.Visibility = Visibility.Visible;
            txtReturnRef.Visibility = Visibility.Visible;
            btnSubmit.Visibility = Visibility.Visible;
        }

        private void btnBookNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string contents = File.ReadAllText(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");
            int temp;
            if (txtReturnRef.Text.Length != 0 && int.TryParse(txtReturnRef.Text, out temp) == true)
            {
                if (contents.Contains("-For Booking Reference: " + txtReturnRef.Text + "-"))
                {
                    using (StreamWriter sw = File.AppendText(extrasPath))
                    {
                        sw.Write("-For Booking Reference: " + txtReturnRef.Text + "- ");
                    }
                    Extras extra1 = new Extras();
                    extra1.Show();
                } else
                {
                    MessageBox.Show("Booking does not exist!");
                }
            } else
            {
                MessageBox.Show("The reference box cannot be blank or invalid!");
            }
        }
    }
}
