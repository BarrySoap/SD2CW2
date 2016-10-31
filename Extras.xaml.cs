using System;
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
    /// Interaction logic for Extras.xaml
    /// </summary>
    public partial class Extras : Window
    {
        private string eveningRequirements;
        private string breakfastRequirements;
        private string hireStartDate;
        private string hireEndDate;
        private string driverName;

        public Extras()
        {
            InitializeComponent();
            hideOptions();
        }

        public void hideOptions()
        {
            txtHireStart.Visibility = Visibility.Hidden;
            txtHireEnd.Visibility = Visibility.Hidden;                              // Hide each label/text box under the
            txtDriverName.Visibility = Visibility.Hidden;                           // car hire option until the user checks
            lblHireStart.Visibility = Visibility.Hidden;                            // the 'car hire' box.
            lblHireEnd.Visibility = Visibility.Hidden;
            lblDriverName.Visibility = Visibility.Hidden;
            txtHireStart.Text = " ";
            txtHireEnd.Text = " ";                                                  // These values cannot be blank as the validator below
            txtDriverName.Text = " ";                                               // depends on whether the fields are blank or not.
            txtEveningDietary.IsEnabled = false;
            txtBreakDietary.IsEnabled = false;
        }

        private void checkMeals_Checked(object sender, RoutedEventArgs e)
        {
            txtEveningDietary.IsEnabled = true;                                     // Allow the user to input dietary retrictions if
            txtEveningDietary.Text = "";                                            // the 'Evening Meals' check box is checked.
        }

        private void checkBreakfast_Checked(object sender, RoutedEventArgs e)
        {
            txtBreakDietary.IsEnabled = true;                                       // Same as above, but for breakfast.
            txtBreakDietary.Text = "";
        }

        private void checkCarHire_Checked(object sender, RoutedEventArgs e)
        {
            txtHireStart.Visibility = Visibility.Visible;                           // Car hire is checked, so show all of
            txtHireEnd.Visibility = Visibility.Visible;                             // the associated labels/text boxes
            txtDriverName.Visibility = Visibility.Visible;
            lblHireStart.Visibility = Visibility.Visible;
            lblHireEnd.Visibility = Visibility.Visible;
            lblDriverName.Visibility = Visibility.Visible;
            txtHireStart.Text = "";                                                 // Make the fields blank to aid the
            txtHireEnd.Text = "";                                                   // validator.
            txtDriverName.Text = "";
        }

        private void checkCarHire_Unchecked(object sender, RoutedEventArgs e)
        {
            txtHireStart.Visibility = Visibility.Hidden;
            txtHireEnd.Visibility = Visibility.Hidden;                              // Hide the car hire options if
            txtDriverName.Visibility = Visibility.Hidden;                           // the 'Car Hire' check box is
            lblHireStart.Visibility = Visibility.Hidden;                            // unchecked.
            lblHireEnd.Visibility = Visibility.Hidden;
            lblDriverName.Visibility = Visibility.Hidden;
        }

        private void checkBreakfast_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBreakDietary.IsEnabled = false;                                      // Hide the breakfast options again if the
            txtBreakDietary.Text = "Add any dietary requirements here!";            // box becomes unchecked after being checked.
        }

        private void checkMeals_Unchecked(object sender, RoutedEventArgs e)
        {
            txtEveningDietary.IsEnabled = false;                                    // Same as above, for evening meals
            txtEveningDietary.Text = "Add any dietary requirements here!";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (checkMeals.IsChecked == true && txtEveningDietary.Text.Length == 0)             // Check if the user has asked for evening meals, but left the dietary field blank.
            {
                MessageBox.Show("As you have checked the box for evening meals, please enter some dietary requirements! If none, type N/A.");
            } else
            {
                eveningRequirements = txtEveningDietary.Text;
            }

            if (checkBreakfast.IsChecked == true && txtBreakDietary.Text.Length == 0)           // Same as above, with breakfast.
            {
                MessageBox.Show("As you have checked the box for breakfast, please enter some dietary requirements! If none, type N/A.");
            } else
            {
                breakfastRequirements = txtBreakDietary.Text;
            }

            if (checkCarHire.IsChecked == true && txtHireStart.Text.Length == 0 || txtHireEnd.Text.Length == 0 || txtDriverName.Text.Length == 0)
            {
                MessageBox.Show("As you have checked the box for car hire, the encompassed fields cannot be blank!");
            } else
            {
                hireStartDate = txtHireStart.Text;
                hireEndDate = txtHireEnd.Text;
                driverName = txtDriverName.Text;
            }
        }
    }
}
