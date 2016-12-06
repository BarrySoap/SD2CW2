using System;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AmendCBG.xaml
    /// </summary>
    public partial class AmendCBG : Window
    {
        int selectedItem = 0;
        string custPath = @"D:\Coursework 2\Coursework2\Records\Customer Records.txt";
        List<string> updatedLines = new List<string>();
        string[] custLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Customer Records.txt");
        string[] bookLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");
        string[] guestLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Guest Records.txt");
        //string[] extrasLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Extras Records.txt");
        string[] words;

        public AmendCBG()
        {
            InitializeComponent();
            hideOptions();
        }

        public void hideOptions()
        {
            lblRefNumber.Visibility = Visibility.Hidden;
            txtRefNumber.Visibility = Visibility.Hidden;
            cmbEditDel.Visibility = Visibility.Hidden;
            btnAccept.Visibility = Visibility.Hidden;
            lblSelect.Visibility = Visibility.Hidden;
            cmbSelect.Visibility = Visibility.Hidden;
            lblNewValue.Visibility = Visibility.Hidden;
            txtNewValue.Visibility = Visibility.Hidden;
            btnSaveChanges.Visibility = Visibility.Hidden;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            cmbEditDel.Visibility = Visibility.Visible;
            btnAccept.Visibility = Visibility.Visible;
            lblRefNumber.Visibility = Visibility.Visible;
            txtRefNumber.Visibility = Visibility.Visible;

            switch (cmbAmendChoice.SelectedIndex)
            {
                case -1:
                    break;
                case 0:
                    cmbEditDel.Items.Clear();
                    cmbEditDel.Items.Add("Edit Customer");
                    selectedItem = 0;
                    break;
                case 1:
                    cmbEditDel.Items.Clear();
                    cmbEditDel.Items.Add("Edit Booking");
                    selectedItem = 1;
                    break;
                case 2:
                    cmbEditDel.Items.Clear();
                    cmbEditDel.Items.Add("Edit Guests");
                    selectedItem = 2;
                    break;
                case 3:
                    cmbEditDel.Items.Clear();
                    cmbEditDel.Items.Add("Add Extras");
                    cmbEditDel.Items.Add("Remove Extras");
                    selectedItem = 3;
                    break;
            }
        }
        
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            int temp;
            if (txtRefNumber.Text != "" && int.TryParse(txtRefNumber.Text, out temp)) 
            {
                lblSelect.Visibility = Visibility.Visible;
                cmbSelect.Visibility = Visibility.Visible;
                lblNewValue.Visibility = Visibility.Visible;
                txtNewValue.Visibility = Visibility.Visible;
                btnSaveChanges.Visibility = Visibility.Visible;

                if (selectedItem == 0)
                {
                    lblSelect.Content = "Edit Customer:";
                    cmbSelect.Items.Clear();
                    cmbSelect.Items.Add("First Name");
                    cmbSelect.Items.Add("Last Name");
                    cmbSelect.Items.Add("Address");
                }

                if (selectedItem == 1)
                {
                    lblSelect.Content = "Edit Booking:";
                    cmbSelect.Items.Clear();
                    cmbSelect.Items.Add("Arrival Date");
                    cmbSelect.Items.Add("Departure Date");
                }

                if (selectedItem == 2)
                {
                    lblSelect.Content = "Edit Guests:";
                    cmbSelect.Items.Clear();
                    cmbSelect.Items.Add("First Name");
                    cmbSelect.Items.Add("Last Name");
                    cmbSelect.Items.Add("Passport Number");
                    cmbSelect.Items.Add("Age");
                }

                if (selectedItem == 3)
                {
                    lblSelect.Content = "Edit Extras:";
                    cmbSelect.Items.Clear();
                    cmbSelect.Items.Add("Add Breakfast Meals");
                    cmbSelect.Items.Add("Add Evening Meals");
                    cmbSelect.Items.Add("Add Car Hire");
                    lblNewValue.Content = "For amount of Days:";
                }
            } else
            {
                MessageBox.Show("Reference Number field cannot be blank!");
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (lblSelect.Content.ToString() == "Edit Customer:")
            {
                switch (cmbSelect.SelectedIndex)
                {
                    case -1:
                        break;
                    case 0:
                        updatedLines.Clear();
                        foreach (string line in custLines)
                        {
                            if (line.Contains("-For Customer Reference: " + txtRefNumber.Text + "-"))
                            {
                                words = line.Split(' ');
                                string temp = line.Replace(words[4], txtNewValue.Text + ",");
                                updatedLines.Add(temp);
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(custPath, updatedLines);
                        break;
                    case 1:
                        updatedLines.Clear();
                        foreach (string line in custLines)
                        {
                            if (line.Contains("-For Customer Reference: " + txtRefNumber.Text + "-"))
                            {
                                words = line.Split(' ');
                                string temp = line.Replace(words[5], txtNewValue.Text + ",");
                                updatedLines.Add(temp);
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(custPath, updatedLines);
                        break;
                    case 2:
                        break;
                }
            }
        }
    }
}
