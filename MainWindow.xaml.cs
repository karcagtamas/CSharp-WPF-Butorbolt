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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2019_01_03_Butorbolt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var listag = AlapanyagModel.Select();
            listag.Insert(0, new AlapanyagModel());
            cboAlapanyagKeres.ItemsSource = listag;
            cboAlapanyagKeres.DisplayMemberPath = "Megnevezes";
            cboAlapanyagKeres.SelectedValuePath = "Id";
        }

        private void btnKeres_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
