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

namespace oefDataGrid
{
    /// <summary>
    /// Interaction logic for frmSale.xaml
    /// </summary>
    public partial class frmSale : Window
    {
        public frmSale()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            dgSale.ItemsSource = HaalLijstMetSale();

            cmbBooks.ItemsSource = HaalLijstMetBoekenOp();

            cmBoeken.ItemsSource = HaalLijstMetBoekenOp();
        }

        private List<Sale> HaalLijstMetSale()
        {
            return new List<Sale>()
            {
            new Sale() {Stor_id = 1, Qty = 5, Ord_num = "order 1", Book = new Book() {Title_id = "1", Title="Java"} },
            new Sale() {Stor_id = 2, Qty = 3, Ord_num = "order 2", Book =  new Book() { Title_id = "2", Title = "jsp" } },
            new Sale() {Stor_id = 3, Qty = 1, Ord_num = "order 3", Book = new Book() { Title_id = "3", Title = "c#" } },
            new Sale() {Stor_id = 4, Qty = 2, Ord_num = "order 4", Book = new Book() { Title_id = "5", Title = "Swift" } },
            };
        }

        private List<Book> HaalLijstMetBoekenOp()
        {
            return new List<Book>()
            {
             new Book() { Title_id = "1", Title = "java" },
             new Book() { Title_id = "2", Title = "jsp" },
             new Book() { Title_id = "3", Title = "c#" },
             new Book() { Title_id = "4", Title = "vb.net" },
             new Book() { Title_id = "5", Title = "Swift" }
            };
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Sale b = dgSale.SelectedItem as Sale;
            if (b.IsValid() && b != null)
            {
                MessageBox.Show("doe een update");
            }else
            {
                MessageBox.Show(b.Error);
            }
        }
    }
}
