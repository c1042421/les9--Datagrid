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

namespace oefDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataManager dataManager;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataManager = new DataManager();

            cmbStores.ItemsSource = dataManager.GetStores();
            cmbStores.DisplayMemberPath = "Stor_name";
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            int qty;

            if (int.TryParse(txtQuantity.Text, out qty))
            {
               
            }
        }

        private void cmbStores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Store store = (Store)cmbStores.SelectedItem;

            dgrSale.ItemsSource = null;
            dgrSale.ItemsSource = store.LijstSale;
        }
    }
}
