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

namespace _2019_01_03_Butorbolt
{
    /// <summary>
    /// Interaction logic for ButorReszletek.xaml
    /// </summary>
    public partial class ButorReszletek : Window
    {
        int? id = null;
        public ButorModel Model { get; private set; }
        public ButorReszletek()
        {
            InitializeComponent();
            var listag = AlapanyagModel.Select();
            listag.Insert(0, new AlapanyagModel());
            cboAlapanyag.ItemsSource = listag;
            cboAlapanyag.DisplayMemberPath = "Megnevezes";
            cboAlapanyag.SelectedValuePath = "Id";
        }

        public ButorReszletek(ButorModel model) :this()
        {
            id = model.Id;
            txtAr.Text = model.Ar.ToString();
            txtMegnevezes.Text = model.Megnevezes;
            txtSzin.Text = model.Szin;
            dpSzallitas.SelectedDate = model.Szallitas;
            cboAlapanyag.SelectedValue = model.Alapanyag;
        }

        private bool KotelezoMezoEllenorzes()
        {
            if (txtMegnevezes.Text == "")
            {
                txtMegnevezes.Focus();
                return false;
            }
            if (cboAlapanyag.SelectedValue == null)
            {
                cboAlapanyag.IsDropDownOpen = true;
                return false;
            }
            if (txtAr.Text != "" && !decimal.TryParse(txtAr.Text, out decimal x))
            {
                txtAr.Focus();
                return false;
            }
            return true;
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (KotelezoMezoEllenorzes())
            {
                this.Model = new ButorModel()
                {
                    Megnevezes = txtMegnevezes.Text,
                    Alapanyag = (int)cboAlapanyag.SelectedValue,
                    Szallitas = dpSzallitas.SelectedDate,
                    Ar = txtAr.Text == "" ? null : (decimal?)decimal.Parse(txtAr.Text),
                    Szin = txtSzin.Text,

                    AlapanyagNev = cboAlapanyag.Text
                };

                try
                {
                    if (id == null) // INSERT
                    {
                        this.Model.Id = ButorModel.Insert(this.Model);
                    }
                    else
                    {
                        this.Model.Id = (int)id;
                        ButorModel.Update(this.Model);
                    }

                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("HIBA: " + ex.Message);
                }
                
            }
        }

        private void btnMegsem_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
