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
                    MessageBox.Show("Case 0");
                    break;
                case 1:
                    MessageBox.Show("Case 1");
                    break;
                case 2:
                    MessageBox.Show("Case 2");
                    break;
                case 3:
                    MessageBox.Show("Case 3");
                    break;
                case 4:
                    MessageBox.Show("Case 4");
                    break;
                case 5:
                    MessageBox.Show("Case 5");
                    break;
                case 6:
                    MessageBox.Show("Case 6");
                    break;
                case 7:
                    MessageBox.Show("Case 7");
                    break;
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
