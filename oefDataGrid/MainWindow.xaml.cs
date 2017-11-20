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
        List<Sale> sales;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sales = new List<Sale>();

            sales.Add(new Sale(1, "20", 3, "NO Payterms", new Book(20, "5", "Books", "3", "Horror")));
            sales.Add(new Sale(2, "15", 3, "NO Payterms", new Book(20, "5", "Harry Potter", "5", "Thriller")));
            sales.Add(new Sale(3, "25", 3, "NO Payterms", new Book(20, "5", "Game Of Thrones", "7", "Thriller")));
            sales.Add(new Sale(4, "30", 3, "NO Payterms", new Book(20, "5", "Het meisje in de trein", "2", "Horror")));


            dgrSale.ItemsSource = sales;
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            int qty;

            if (int.TryParse(txtQuantity.Text, out qty))
            {
                Sale sale = new Sale(2, txtOrderNummer.Text, DateTime.Now, qty, txtPayterms.Text, new Book(20, "2", txtTitle.Text, "2", "Horror"));
                if (sale.IsValid())
                {
                    sales.Add(sale);
                }
            }

            dgrSale.ItemsSource = null;
            dgrSale.ItemsSource = sales;
        }
    }
}
