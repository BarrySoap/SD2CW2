﻿using System;
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
 * Class Purpose: Contains logic for adding extras to a booking.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    public partial class Extras : Window
    {
        private string extrasPath = @"D:\Coursework 2\Coursework2\Records\Extras Records.txt";         // Initialise the path of the record file.

        //******* Initialise variables for an extras record. ******/
        private string eveningRequirements;
        private string breakfastRequirements;
        private string hireStartDate;
        private string hireEndDate;
        private string driverName;
        //*********************************************************/

        public Extras()
        {
            InitializeComponent();
            if (!File.Exists(extrasPath))                               // If the extras record file doesn't exist,
            {
                using (StreamWriter sw = File.CreateText(extrasPath))
                {                                                       // it will be created with some helping text.
                    sw.WriteLine("Evening Meals Dietary Requirements (EVE:), Breakfast Dietary Requirements (BK:), Car Hire (DN:)" + Environment.NewLine);
                }
            }
            hideOptions();
        }

        //*********** This method will hide specific variables until they are needed in the GUI ******************/
        public void hideOptions()
        {
            dpStartDate.Visibility = Visibility.Hidden;
            dpEndDate.Visibility = Visibility.Hidden;                              // Hide each label/text box under the
            txtDriverName.Visibility = Visibility.Hidden;                           // car hire option until the user checks
            lblHireStart.Visibility = Visibility.Hidden;                            // the 'car hire' box.
            lblHireEnd.Visibility = Visibility.Hidden;
            lblDriverName.Visibility = Visibility.Hidden;
            dpStartDate.Text = " ";
            dpEndDate.Text = " ";                                                  // These values cannot be blank as the validator below
            txtDriverName.Text = " ";                                               // depends on whether the fields are blank or not.
            txtEveningDietary.IsEnabled = false;
            txtBreakDietary.IsEnabled = false;
        }
        //********************************************************************************************************/

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
            dpStartDate.Visibility = Visibility.Visible;                           // Car hire is checked, so show all of
            dpEndDate.Visibility = Visibility.Visible;                             // the associated labels/text boxes
            txtDriverName.Visibility = Visibility.Visible;
            lblHireStart.Visibility = Visibility.Visible;
            lblHireEnd.Visibility = Visibility.Visible;
            lblDriverName.Visibility = Visibility.Visible;
            dpStartDate.Text = "";                                                 // Make the fields blank to aid the
            dpEndDate.Text = "";                                                   // validator.
            txtDriverName.Text = "";
        }

        private void checkCarHire_Unchecked(object sender, RoutedEventArgs e)
        {
            dpStartDate.Visibility = Visibility.Hidden;
            dpEndDate.Visibility = Visibility.Hidden;                              // Hide the car hire options if
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
            if (checkMeals.IsChecked == true)             // Check if the user has asked for evening meals, but left the dietary field blank.
            {
                if (txtEveningDietary.Text.Length == 0 || txtEveningDietary.Text == "Add any dietary requirements here!")
                {
                    MessageBox.Show("As you have checked the box for evening meals, please enter some dietary requirements! If none, type N/A.");
                } else
                {
                    eveningRequirements = txtEveningDietary.Text;
                    using (StreamWriter sw = File.AppendText(extrasPath))
                    {
                        sw.Write("EVE:" + eveningRequirements + ", ");
                    }
                }
            } 

            if (checkBreakfast.IsChecked == true)           // Same as above, with breakfast.
            {
                if (txtBreakDietary.Text.Length == 0 || txtBreakDietary.Text == "Add any dietary requirements here!")
                {
                    MessageBox.Show("As you have checked the box for breakfast, please enter some dietary requirements! If none, type N/A.");
                } else
                {
                    breakfastRequirements = txtBreakDietary.Text;
                    using (StreamWriter sw = File.AppendText(extrasPath))
                    {
                        sw.Write("BK:" + breakfastRequirements + ", ");
                    }
                }
            }

            if (checkCarHire.IsChecked == true)
            {
                if (dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null || txtDriverName.Text.Length == 0)
                {
                    MessageBox.Show("As you have checked the box for car hire, the encompassed fields cannot be blank!");
                } else
                {
                    hireStartDate = dpStartDate.Text;
                    hireEndDate = dpEndDate.Text;
                    driverName = txtDriverName.Text;
                    using (StreamWriter sw = File.AppendText(extrasPath))
                    {
                        sw.Write("DN:" + driverName + ", " + (DateTime.Parse(hireEndDate) - DateTime.Parse(hireStartDate)).TotalDays + Environment.NewLine + Environment.NewLine);
                    }
                }
            }
        }
    }
}
