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

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Allows the mutation of customers/bookings/guests.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    public partial class AmendCBG : Window
    {
        private int selectedItem = 0;   // This variable is used to edit the items of a combo box, filing down user input.

        //*************/ Variables used to allow the program to find files. /****************/
        private string custPath = @"D:\Coursework 2\Coursework2\Records\Customer Records.txt";
        private string bookPath = @"D:\Coursework 2\Coursework2\Records\Booking Records.txt";
        private string guestsPath = @"D:\Coursework 2\Coursework2\Records\Guest Records.txt";
        private string extrasPath = @"D:\Coursework 2\Coursework2\Records\Extras Records.txt";
        //***********************************************************************************/ 

        private List<string> updatedLines = new List<string>();   // This variable is used to store the content a new file after updating.

        //*************************/ Variables used to store the content of files. /******************************/
        private string[] custLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Customer Records.txt");
        private string[] bookLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");
        private string[] guestLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Guest Records.txt");
        private string[] extrasLines = File.ReadAllLines(@"D:\Coursework 2\Coursework2\Records\Extras Records.txt");
        //********************************************************************************************************/

        private string[] words;   // This variable is used to split a specific line, which allows us to select a word by index.

        public AmendCBG()
        {
            InitializeComponent();
            hideOptions();
        }

        //This method will hide specific variables until they are needed in the GUI
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
            lblGuestValue.Visibility = Visibility.Hidden;
            txtGuestsValue.Visibility = Visibility.Hidden;
        }
        //********************************************/

        public void editCustomer()
        {
            if (lblSelect.Content.ToString() == "Edit Customer:")                                       // This will check if the user has asked to change the 
            {                                                                                           // attributes of a customer.
                switch (cmbSelect.SelectedIndex)                                                        // Using the selected option in the combo box (SelectedIndex)
                {
                    case -1:                                                                            // Break if the selected option is the default (blank)
                        break;
                    case 0:                                                                             // If the user has asked to change the first name (at index 0),
                        updatedLines.Clear();                                                           // Clear the new content of the file from previous inputs.
                        foreach (string line in custLines)                                              // Recursively check each line of the customer record
                        {
                            if (line.Contains("-For Customer Reference: " + txtRefNumber.Text + "-"))   // for a line containing "-For Customer Reference: " and the
                            {                                                                           // specified reference number.
                                words = line.Split(' ');                                                // When found, split the line into separate words.
                                string temp = line.Replace(words[4], txtNewValue.Text + ",");           // Replace the word at index 4 (always first name) with the new requested value.
                                updatedLines.Add(temp);                                                 // Add the updated line to the new content of the file.
                                continue;                                                               // Exit the current iteration of the foreach loop.
                            }
                            updatedLines.Add(line);                                                     // This will keep each line of the original file, as well as changing the updated line.
                        }

                        File.WriteAllLines(custPath, updatedLines);                                     // Write all lines back to the original file path.
                        break;
                    case 1:                                                                             // If the user has asked to change the second name (at index 1),
                        updatedLines.Clear();                                                           // Clear the new content of the file from previous inputs.
                        foreach (string line in custLines)
                        {
                            if (line.Contains("-For Customer Reference: " + txtRefNumber.Text + "-"))
                            {
                                words = line.Split(' ');
                                string temp = line.Replace(words[5], txtNewValue.Text + ",");           // Same as before, but replace the word at index 5 (always second name due to validation logic)
                                updatedLines.Add(temp);
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(custPath, updatedLines);
                        break;
                    case 2:                                                                             // If the user has asked to change the address (at index 2),
                        updatedLines.Clear();                                                           // Clear the new content of the file from previous inputs.
                        foreach (string line in custLines)
                        {
                            if (line.Contains("-For Customer Reference: " + txtRefNumber.Text + "-"))
                            {
                                words = line.Split(' ');
                                string[] words2 = txtNewValue.Text.Split(' ');
                                string temp = line.Replace(words[6], words2[0]).Replace(words[7], words2[1]).Replace(words[8], words2[2]);      // This will take the 3 words of the existing address value
                                updatedLines.Add(temp);                                                                                         // and replace them respectively with the new value in the file.
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(custPath, updatedLines);
                        break;
                }
            }
        }

        public void editBooking()
        {
            if (lblSelect.Content.ToString() == "Edit Booking:")                                        // This will check if the user has asked to change the 
            {                                                                                           // attributes of a booking.
                switch (cmbSelect.SelectedIndex)                                                        // Using the selected option in the combo box (SelectedIndex)
                {
                    case -1:                                                                            // Break if the selected option is the default (blank)
                        break;
                    case 0:                                                                             // If the user has asked to change the arrival date (at index 0),
                        updatedLines.Clear();                                                           // Clear the new content of the file from previous inputs.
                        foreach (string line in bookLines)                                              // Recursively check each line of the booking record
                        {
                            if (line.Contains("-For Booking Reference: " + txtRefNumber.Text + "-"))    // for a line containing "-For Customer Reference: " and the
                            {                                                                           // specified reference number.
                                words = line.Split(' ');                                                // When found, split the line into separate words.
                                string temp = line.Replace(words[4], txtNewValue.Text + ",");           // Replace the word at index 4 (always first name) with the new requested value.
                                updatedLines.Add(temp);                                                 // Add the updated line to the new content of the file.
                                continue;                                                               // Exit the current iteration of the foreach loop.
                            }
                            updatedLines.Add(line);                                                     // This will keep each line of the original file, as well as changing the updated line.
                        }

                        File.WriteAllLines(bookPath, updatedLines);                                     // Write all lines back to the original file path.
                        break;
                    case 1:                                                                             // Check if the user has asked to change the departure date (at index 1)
                        updatedLines.Clear();
                        foreach (string line in bookLines)
                        {
                            if (line.Contains("-For Booking Reference: " + txtRefNumber.Text + "-"))
                            {
                                words = line.Split(' ');
                                string temp = line.Replace(words[6], txtNewValue.Text + ",");
                                updatedLines.Add(temp);
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(bookPath, updatedLines);
                        break;
                }
            }
        }

        public void editGuests()
        {
            if (lblSelect.Content.ToString() == "Edit Guests:")                                         // This will check if the user has asked to change the 
            {                                                                                           // attributes of their guest(s).
                switch (cmbSelect.SelectedIndex)
                {
                    case -1:
                        break;
                    case 0:                                                                             // Check if the user has asked to change the guest(s) first name (at index 0)
                        updatedLines.Clear();
                        foreach (string line in guestLines)
                        {
                            if (line.Contains("-For Booking Reference: " + txtRefNumber.Text + "-") && line.Contains(txtGuestsValue.Text))
                            {
                                words = line.Split(' ');
                                string temp = line.Replace(words[4], txtNewValue.Text + ",");
                                updatedLines.Add(temp);
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(guestsPath, updatedLines);
                        break;
                    case 1:                                                                             // Check if the user has asked to change the guest(s) second name (at index 1)
                        updatedLines.Clear();
                        foreach (string line in guestLines)
                        {
                            if (line.Contains("-For Booking Reference: " + txtRefNumber.Text + "-") && line.Contains(txtGuestsValue.Text))
                            {
                                words = line.Split(' ');
                                string temp = line.Replace(words[5], txtNewValue.Text + ",");
                                updatedLines.Add(temp);
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(guestsPath, updatedLines);
                        break;
                    case 2:                                                                             // Check if the user has asked to change the guest(s) passport number (at index 2)
                        updatedLines.Clear();
                        foreach (string line in guestLines)
                        {
                            if (line.Contains("-For Booking Reference: " + txtRefNumber.Text + "-") && line.Contains(txtGuestsValue.Text))
                            {
                                words = line.Split(' ');
                                string temp = line.Replace(words[6], txtNewValue.Text + ",");
                                updatedLines.Add(temp);
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(guestsPath, updatedLines);
                        break;
                    case 3:                                                                             // Check if the user has asked to change the guest(s) age (at index 3)
                        updatedLines.Clear();
                        foreach (string line in guestLines)
                        {
                            if (line.Contains("-For Booking Reference: " + txtRefNumber.Text + "-") && line.Contains(txtGuestsValue.Text))
                            {
                                words = line.Split(' ');
                                string temp = line.Replace(words[7], txtNewValue.Text);
                                updatedLines.Add(temp);
                                continue;
                            }
                            updatedLines.Add(line);
                        }

                        File.WriteAllLines(guestsPath, updatedLines);
                        break;

                }
            }
        }

        public void editExtras()
        {
            if (lblSelect.Content.ToString() == "Edit Extras:")                                         // This will check if the user has asked to change the
            {                                                                                           // attributes of their extras.
                switch (cmbSelect.SelectedIndex)
                {
                    case -1:
                        break;
                    case 0:                                                                             // Check if the user has asked to add breakfast (at index 0)
                        updatedLines.Clear();
                        foreach (string line in extrasLines)
                        {
                            if (line.Contains("-For Booking Reference: " + txtRefNumber.Text + "-"))
                            {
                                words = line.Split(' ');
                                if (line.Contains("BK:"))
                                {
                                    string temp = line.Insert(27, txtNewValue.Text + ", ");
                                    updatedLines.Add(temp);
                                }
                                continue;
                            }
                            updatedLines.Add(line);
                        }
                        File.WriteAllLines(extrasPath, updatedLines);
                        break;
                }
            }
        }

        //******* This methods is used to recursively check, and then remove lines*******/
        public void removeExtras()
        {
            updatedLines.Clear();
            foreach (string line in extrasLines)
            {
                if (line.Contains("-For Booking Reference: " + txtRefNumber.Text + "-"))
                {
                    words = line.Split(' ');
                    string temp = line.Replace("EVE:" + txtNewValue.Text, "");
                    updatedLines.Add(temp);
                    continue;
                }
                updatedLines.Add(line);
            }
            File.WriteAllLines(extrasPath, updatedLines);
        }
        //*******************************************************************************/

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            cmbEditDel.Visibility = Visibility.Visible;
            btnAccept.Visibility = Visibility.Visible;
            lblRefNumber.Visibility = Visibility.Visible;
            txtRefNumber.Visibility = Visibility.Visible;

            switch (cmbAmendChoice.SelectedIndex)
            {
                case -1:                                        // Based on the selected item of 'AmendChoice' combo box,
                    break;                                      // the next combo box's items will be different.
                case 0:
                    cmbEditDel.Items.Clear();                   // This case statement allows the user to choose what
                    cmbEditDel.Items.Add("Edit Customer");      // they wish to edit.
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
            if (txtRefNumber.Text != "" && int.TryParse(txtRefNumber.Text, out temp))   // Check that the reference number is valid/not blank.
            {
                lblSelect.Visibility = Visibility.Visible;
                cmbSelect.Visibility = Visibility.Visible;
                lblNewValue.Visibility = Visibility.Visible;
                txtNewValue.Visibility = Visibility.Visible;
                btnSaveChanges.Visibility = Visibility.Visible;

                if (selectedItem == 0)                                  // If the user chose to edit a customer in the previous combo box,
                {
                    lblSelect.Content = "Edit Customer:";               // Change the label identifier to edit a customer.
                    cmbSelect.Items.Clear();
                    cmbSelect.Items.Add("First Name");                  // Add each customer attribute to the final combo box.
                    cmbSelect.Items.Add("Last Name");
                    cmbSelect.Items.Add("Address");
                    lblGuestValue.Visibility = Visibility.Hidden;
                    txtGuestsValue.Visibility = Visibility.Hidden;
                }

                if (selectedItem == 1)
                {
                    lblSelect.Content = "Edit Booking:";                  // Or add each booking attribute to the combo box.
                    cmbSelect.Items.Clear();
                    cmbSelect.Items.Add("Arrival Date");
                    cmbSelect.Items.Add("Departure Date");
                    lblGuestValue.Visibility = Visibility.Hidden;
                    txtGuestsValue.Visibility = Visibility.Hidden;
                }

                if (selectedItem == 2)
                {
                    lblSelect.Content = "Edit Guests:";                  // Or add each guest attribute to the combo box.
                    cmbSelect.Items.Clear();
                    cmbSelect.Items.Add("First Name");
                    cmbSelect.Items.Add("Last Name");
                    cmbSelect.Items.Add("Passport Number");
                    cmbSelect.Items.Add("Age");
                    lblGuestValue.Visibility = Visibility.Visible;
                    txtGuestsValue.Visibility = Visibility.Visible;
                }

                if (selectedItem == 3)
                {
                    lblSelect.Content = "Edit Extras:";                  // Or add each extras attribute to the combo box.
                    cmbSelect.Items.Clear();
                    cmbSelect.Items.Add("Add Breakfast Meals");
                    cmbSelect.Items.Add("Add Evening Meals");
                    cmbSelect.Items.Add("Add Car Hire");
                    lblNewValue.Content = "For amount of Days:";
                    lblGuestValue.Visibility = Visibility.Hidden;
                    txtGuestsValue.Visibility = Visibility.Hidden;
                }
            } else
            {
                MessageBox.Show("Reference Number field cannot be blank!");
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewValue.Text != "")                                     // If the user has tried to replace a value with nothing,
            {                                                               // an error will be thrown.
                editCustomer();                                             // Call each respective method to edit customers,
                editBooking();                                              // bookings,
                editGuests();                                               // guests,
                if (cmbEditDel.SelectedIndex == 1)
                {
                    removeExtras();                                         // or extras.
                }
                else if (cmbEditDel.SelectedIndex == 0)
                {
                    editExtras();
                }
            } else
            {
                MessageBox.Show("The new value field cannot be blank!");
            }
        }
    }
}
