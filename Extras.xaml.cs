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

        }
    }
}
