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
            txtHireStart.Visibility = Visibility.Hidden;
            txtHireEnd.Visibility = Visibility.Hidden;                              // Hide each label/text box under the
            txtDriverName.Visibility = Visibility.Hidden;                           // car hire option until the user checks
            lblHireStart.Visibility = Visibility.Hidden;                            // the 'car hire' box.
            lblHireEnd.Visibility = Visibility.Hidden;
            lblDriverName.Visibility = Visibility.Hidden;
        }

        private void checkMeals_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBreakfast_Checked(object sender, RoutedEventArgs e)
        {

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
    }
}
