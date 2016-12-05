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
    /// Interaction logic for AmendCBG.xaml
    /// </summary>
    public partial class AmendCBG : Window
    {
        public AmendCBG()
        {
            InitializeComponent();
            hideOptions();
        }

        public void hideOptions()
        {
            cmbEditDel.Visibility = Visibility.Hidden;
            btnAccept.Visibility = Visibility.Hidden;
            lblSelect.Visibility = Visibility.Hidden;
            cmbSelect.Visibility = Visibility.Hidden;
            lblNewValue.Visibility = Visibility.Hidden;
            txtNewValue.Visibility = Visibility.Hidden;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            cmbEditDel.Visibility = Visibility.Visible;
            btnAccept.Visibility = Visibility.Visible;

            switch (cmbAmendChoice.SelectedIndex)
            {
                case -1:
                    break;
                case 0:
                    cmbEditDel.Items.Add("Edit Customer");
                    cmbEditDel.Items.Add("Delete Customer");
                    break;
                case 1:
                    cmbEditDel.Items.Add("Edit Booking");
                    cmbEditDel.Items.Add("Delete Booking");
                    break;
                case 2:
                    cmbEditDel.Items.Add("Edit Guests");
                    cmbEditDel.Items.Add("Delete Guests");
                    break;
                case 3:
                    cmbEditDel.Items.Add("Add Extras");
                    cmbEditDel.Items.Add("Remove Extras");
                    break;
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
