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
        List<ButorModel> butorok = new List<ButorModel>();
        public MainWindow()
        {
            InitializeComponent();
            var listag = AlapanyagModel.Select();
            listag.Insert(0, new AlapanyagModel());
            cboAlapanyagKeres.ItemsSource = listag;
            cboAlapanyagKeres.DisplayMemberPath = "Megnevezes";
            cboAlapanyagKeres.SelectedValuePath = "Id";

            
            butorok = ButorModel.Select(null, "");
            dgLista.ItemsSource = butorok;
            dgLista.Items.Refresh();
            
        }

        private void btnKeres_Click(object sender, RoutedEventArgs e)
        {
            butorok = ButorModel.Select((int?)cboAlapanyagKeres.SelectedValue, txtMegnevezesKeres.Text);
            dgLista.ItemsSource = butorok;
            dgLista.Items.Refresh();
        }

        private void btnUj_Click(object sender, RoutedEventArgs e)
        {
            var ablak = new ButorReszletek();
            if (ablak.ShowDialog() == true)
            {
                butorok.Add(ablak.Model);
                dgLista.Items.Refresh();
            }
        }

        private void btnModosit_Click(object sender, RoutedEventArgs e)
        {
            if (dgLista.SelectedItem != null)
            {
                var butor = (ButorModel)dgLista.SelectedItem;
                var ablak = new ButorReszletek(butor);
                if (ablak.ShowDialog() == true)
                {
                    int index = butorok.IndexOf(butor);
                    butorok[index] = ablak.Model;
                    dgLista.Items.Refresh();
                }
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (dgLista.SelectedItem != null)
            {
                var butor = (ButorModel)dgLista.SelectedItem;
                if (MessageBox.Show("Biztos?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ButorModel.Delete(butor);
                    butorok.Remove(butor);
                    dgLista.Items.Refresh();
                }
            }
        }
    }
}
