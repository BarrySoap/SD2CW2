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

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: This will validate the existence of a booking, and
 *                controls access to the addition of extras.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    public partial class ExtrasPrompt : Window
    {
        private string extrasPath = @"D:\Coursework 2\Coursework2\Records\Extras Records.txt";         // Initialise the path of the record file.

        public ExtrasPrompt()
        {
            InitializeComponent();
            if (!File.Exists(extrasPath))                               // If the extras record file doesn't exist,
            {
                using (StreamWriter sw = File.CreateText(extrasPath))
                {                                                       // it will be created with some helping text.
                    sw.WriteLine("Evening Meals Dietary Requirements (EM), Breakfast Dietary Requirements (BF), Car Hire (CH)" + Environment.NewLine);
                }
            }
            hideLabelsButtons();
        }

        //*********** This method will hide specific variables until they are needed in the GUI ******************/
        public void hideLabelsButtons()
        {
            lblEnterRef.Visibility = Visibility.Hidden;
            txtReturnRef.Visibility = Visibility.Hidden;
            btnSubmit.Visibility = Visibility.Hidden;
        }
        //********************************************************************************************************/

        // **** If the user says they have a booking, GUI elements will appear, prompting for the ref number. ****/
        private void btnBookYes_Click(object sender, RoutedEventArgs e)
        {
            lblEnterRef.Visibility = Visibility.Visible;
            txtReturnRef.Visibility = Visibility.Visible;
            btnSubmit.Visibility = Visibility.Visible;
        }
        //********************************************************************************************************/

        // ************* If the user says they don't have a booking, the current window will close. **************/
        private void btnBookNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //********************************************************************************************************/

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string contents = File.ReadAllText(@"D:\Coursework 2\Coursework2\Records\Booking Records.txt");         // Initialise the path of the record file.
            int temp;
            if (txtReturnRef.Text.Length != 0 && int.TryParse(txtReturnRef.Text, out temp) == true)                 // If the reference number is valid,
            {
                if (contents.Contains("-For Booking Reference: " + txtReturnRef.Text + "-"))                        // search the booking record file for the
                {                                                                                                   // respective reference number.
                    using (StreamWriter sw = File.AppendText(extrasPath))
                    {                                                                                               // If it exists,
                        sw.Write("-For Booking Reference: " + txtReturnRef.Text + "- ");                            // Add the booking to the extras file,
                    }
                    Extras extra1 = new Extras();                                                                   // and show the extras window.
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
