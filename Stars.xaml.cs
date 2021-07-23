using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for Stars.xaml
    /// </summary>
    public partial class Stars : UserControl
    {
        private List<ToggleButton> stars;
        public Stars()
        {
            InitializeComponent();
            stars = new List<ToggleButton>() {

          T1,T2,T3,T4,T5
            };
        }

        private void T1_Click(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).IsChecked = true;
        }
    }
}
