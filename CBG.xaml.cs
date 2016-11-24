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
    public partial class CBG : Window
    {
        Guests guest1 = new Guests();                               // Creating objects for guests,
        Booking book1 = new Booking();                              //                      bookings,
        Customer cust1 = new Customer();                            //                  and customers. This allows the class to manipulate the classes variables.
        private string customerPath = @"D:\Coursework 2\Coursework2\Customer Records.txt";
        private string bookingPath = @"D:\Coursework 2\Coursework2\Booking Records.txt";
        private string guestsPath = @"D:\Coursework 2\Coursework2\Guest Records.txt";
        private int noOfGuests = 0;

        public CBG()
        {
            InitializeComponent();
            hideAdditions();                                        // Call the hide method below.
            if (!File.Exists(customerPath))
            {
                using (StreamWriter sw = File.CreateText(customerPath))
                {
                    sw.WriteLine("First Name, Last Name, Address" + Environment.NewLine);
                }
            }

            if (!File.Exists(bookingPath))
            {
                using (StreamWriter sw = File.CreateText(bookingPath))
                {
                    sw.WriteLine("Arrival Date, Departure Date" + Environment.NewLine);
                }
            }

            if (!File.Exists(guestsPath))
            {
                using (StreamWriter sw = File.CreateText(guestsPath))
                {
                    sw.WriteLine("First Name, Last Name, Passport Number, Age" + Environment.NewLine);
                }
            }
        }

        public void hideAdditions()
        {
            lblCBG.Visibility = Visibility.Hidden;                  // This method will hide every label and text box so
            btnaddCBG.Visibility = Visibility.Hidden;               // that the user cannot see them before pressing
            lblProperty1.Visibility = Visibility.Hidden;            // the 'Add' buttons.
            lblProperty_5.Visibility = Visibility.Hidden;
            lblProperty2.Visibility = Visibility.Hidden;
            lblProperty3.Visibility = Visibility.Hidden;
            txtCBG1.Visibility = Visibility.Hidden;                 // eg. These hide functions will hide the text boxes
            txtCBG1_5.Visibility = Visibility.Hidden;               // which allow the user to input data. That way,
            txtCBG2.Visibility = Visibility.Hidden;                 // we avoid any exceptions where the user enteres
            txtCBG3.Visibility = Visibility.Hidden;                 // data before deciding to add a customer/booking/guest.
        }

        private void btnAddCust_Click(object sender, RoutedEventArgs e)
        {
            btnaddCBG.Content = "Add Customer";
            btnaddCBG.Visibility = Visibility.Visible;              // The user has chosen to now add a customer, so
            lblProperty1.Visibility = Visibility.Visible;           // the header label and text box labels must now
            lblProperty_5.Visibility = Visibility.Visible;          // appear.
            lblProperty2.Visibility = Visibility.Visible;
            txtCBG1.Text = "";
            txtCBG1_5.Text = "";                                    // Clear the text boxes so that the previous inputs don't stay around.
            txtCBG2.Text = "";
            lblCBG.Visibility = Visibility.Visible;
            lblCBG.Content = "Add a Customer:";                     // Change the content of the labels over the text
            lblProperty1.Content = "First Name:";                   // boxes so that we don't have to create new
            lblProperty_5.Content = "Last Name:";                   // text boxes every time the user chooses to add
            lblProperty2.Content = "Address:";                      // a customer, booking or guest.
            txtCBG1.Visibility = Visibility.Visible;
            txtCBG1_5.Visibility = Visibility.Visible;              // Allow the user to input data.
            txtCBG2.Visibility = Visibility.Visible;
            lblProperty3.Visibility = Visibility.Hidden;            // The third text box isn't needed, so hide the label and text box.
            txtCBG3.Visibility = Visibility.Hidden;
        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            btnaddCBG.Content = "Add Booking";
            btnaddCBG.Visibility = Visibility.Visible;
            lblProperty2.Visibility = Visibility.Visible;
            lblProperty3.Visibility = Visibility.Visible;
            lblCBG.Visibility = Visibility.Visible;
            txtCBG1.Text = "";
            txtCBG1_5.Text = "";                                    // Clear the text boxes so that the previous inputs don't stay around.
            txtCBG2.Text = "";
            lblCBG.Content = "Add a Booking:";                      // Same as above, but by changing the header label,
            lblProperty2.Content = "Arrival Date (dd/mm/yyyy):";    // it allows for an easy validator when pressing the 
            lblProperty3.Content = "Departure Date (dd/mm/yyyy):";  // "Add Booking" button.
            lblProperty1.Visibility = Visibility.Hidden;
            lblProperty_5.Visibility = Visibility.Hidden;
            txtCBG2.Visibility = Visibility.Visible;                // Allow the user to input data.
            txtCBG3.Visibility = Visibility.Visible;
            txtCBG1.Visibility = Visibility.Hidden;                 // Hide the top two text boxes, which are usually
            txtCBG1_5.Visibility = Visibility.Hidden;               // for a first and last name.
        }

        private void btnAddGuest_Click(object sender, RoutedEventArgs e)
        {
            btnaddCBG.Content = "Add Guest";
            btnaddCBG.Visibility = Visibility.Visible;
            lblProperty1.Visibility = Visibility.Visible;           // In this case, we need each label and text box
            lblProperty_5.Visibility = Visibility.Visible;          // because the addition of a guest requires the user
            lblProperty2.Visibility = Visibility.Visible;           // to know the guests' first name, last name, 
            lblProperty3.Visibility = Visibility.Visible;           // passport number and age.
            txtCBG1.Text = "";
            txtCBG1_5.Text = "";                                    // Clear the text boxes so that the previous inputs don't stay around.
            txtCBG2.Text = "";
            txtCBG3.Text = "";
            lblCBG.Visibility = Visibility.Visible;
            lblCBG.Content = "Add a Guest:";
            lblProperty1.Content = "First Name:";
            lblProperty_5.Content = "Last Name:";
            lblProperty2.Content = "Passport Number:";
            lblProperty3.Content = "Age:";
            txtCBG1.Visibility = Visibility.Visible;
            txtCBG1_5.Visibility = Visibility.Visible;              // Allow the user to input data
            txtCBG2.Visibility = Visibility.Visible;
            txtCBG3.Visibility = Visibility.Visible;
        }

        private void btnaddCBG_Click_1(object sender, RoutedEventArgs e)
        {
            if (lblCBG.Content.ToString() == "Add a Customer:")                                             // Check if the header label is for adding a customer. As said above, this makes for an easy validator/check.
            {
                if (txtCBG1.Text != "" && txtCBG1_5.Text != "" && txtCBG2.Text != "")                       // Check if the first/last name and address text boxes aren't blank.
                {
                    cust1.CustomerFirstName = txtCBG1.Text;
                    cust1.CustomerSecondName = txtCBG1_5.Text;                                              // If not, update the object variables with the values of the text boxes.
                    cust1.CustomerAddress = txtCBG2.Text;
                    cust1.CustRefNumber = cust1.CustRefNumber + 1;
                    MessageBox.Show("Your customer reference number is: " + cust1.CustRefNumber);
                    using (StreamWriter sw = File.AppendText(customerPath))
                    {
                        sw.WriteLine("-For Customer Reference: " + cust1.CustRefNumber + "-" + Environment.NewLine + 
                                     cust1.CustomerFirstName + ", " + cust1.CustomerSecondName + ", " + cust1.CustomerAddress + 
                                     Environment.NewLine + Environment.NewLine);
                    }
                } else
                {
                    MessageBox.Show("The above fields must be valid/not blank!");                           // An error is thrown if any of the text boxes are blank.
                }
            } 

            if (lblCBG.Content.ToString() == "Add a Booking:")                                              // Check if the header label is for adding a booking.
            {
                DateTime d;                                                                                 // Initialise a temporary variable for a tryparse.

                if (DateTime.TryParse(txtCBG2.Text, out d) && DateTime.TryParse(txtCBG3.Text, out d))       // If the arrival/departure date text boxes are in DateTime format,
                {
                    book1.ArrivalDate = DateTime.Parse(txtCBG2.Text);                                       // Update the object variables.
                    book1.DepartureDate = DateTime.Parse(txtCBG3.Text);
                    book1.RefNumber = book1.RefNumber + 1;
                    MessageBox.Show("Your booking reference number is: " + book1.RefNumber);
                    using (StreamWriter sw = File.AppendText(bookingPath))
                    {
                        sw.WriteLine("-For Booking Reference: " + book1.RefNumber + "-" + Environment.NewLine + 
                                     book1.ArrivalDate + ", " + book1.DepartureDate + Environment.NewLine + Environment.NewLine);
                    }
                } else
                {
                    MessageBox.Show("The arrival date and departure date boxes must be valid dates!");      // An error is thrown otherwise.
                }
            }

            if (lblCBG.Content.ToString() == "Add a Guest:")                                                // Check if the header label is for adding a guest.
            {
                if (txtCBG1.Text != "" && txtCBG1_5.Text != "" && txtCBG2.Text != "" && txtCBG3.Text != "") // Check to see if the text boxes aren't blank.
                {
                    if (noOfGuests != 4)
                    {
                        guest1.GuestFirstName = txtCBG1.Text;
                        guest1.GuestSecondName = txtCBG1_5.Text;                                                // Update the object variables.
                        guest1.GuestPassNumber = txtCBG2.Text;
                        int temp;
                        if (int.TryParse(txtCBG3.Text, out temp))
                        {
                            guest1.GuestAge = int.Parse(txtCBG3.Text);                                          // Parse the text box content (string) to an int.
                        }
                        noOfGuests = noOfGuests + 1;
                        using (StreamWriter sw = File.AppendText(guestsPath))
                        {
                            sw.WriteLine("-For Booking Reference: " + book1.RefNumber + "-" + Environment.NewLine + 
                                         guest1.GuestFirstName + ", " + guest1.GuestSecondName + ", " + guest1.GuestPassNumber + ", " + guest1.GuestAge + 
                                         Environment.NewLine + Environment.NewLine);
                        }
                    } else
                    {
                        MessageBox.Show("You cannot have more than 4 guests accompanying you!");
                    }
                } else
                {
                    MessageBox.Show("The above fields must not be blank!");                                 // An error is thrown if any of the text boxes are blank.
                }
            }
        }
    }
}
