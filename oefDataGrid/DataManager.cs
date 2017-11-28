using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefDataGrid
{
    class DataManager
    {
        public Book getBookByBookId(string title_id)
        {
            foreach (Book book in GetBooks())
            {
                if (book.Title_id.Equals(title_id))
                {
                    return book;
                }
            }

            return null;
        }

        public ObservableCollection<Book> GetBooks()
        {
            StreamReader reader = new StreamReader("titles.txt");
            ObservableCollection<Book> boeken = new ObservableCollection<Book>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] elements = line.Split(';');

                double price = double.Parse(elements[4]);

                boeken.Add(
                    new Book()
                    {
                        Title_id = elements[0],
                        Title = elements[1],
                        Type = elements[2],
                        Pub_id = elements[3],
                        Price = price
                    }
                );
            }

            return boeken;
        }

        public ObservableCollection<Sale> GetSalesByStoreid(int store_id)
        {
            ObservableCollection<Sale> sales = new ObservableCollection<Sale>();

            foreach (Sale sale in getSales())
            {
                if (sale.Stor_id.Equals(store_id))
                {
                    sales.Add(sale);
                }
            }

            return sales;
        }

        public ObservableCollection<Sale> getSales()
        {

           StreamReader reader = new StreamReader("sales.txt");
            ObservableCollection<Sale> sales = new ObservableCollection<Sale>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] elements = line.Split(';');

                int storId = int.Parse(elements[0]);
                DateTime orderDate = DateTime.Parse(elements[2]);
                int qty = int.Parse(elements[3]);

                sales.Add(
                    new Sale()
                    {
                        Stor_id = storId,
                        Ord_num = elements[1],
                        Ord_date = orderDate,
                        Qty = qty,
                        Payterms = elements[4],
                        Book = getBookByBookId(elements[5])
                    }
                );
            }

            return sales;
        }

        public ObservableCollection<Store> GetStores()
        {
            StreamReader reader = new StreamReader("stores.txt");
            ObservableCollection<Store> stores = new ObservableCollection<Store>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] elements = line.Split(';');

                int storId = int.Parse(elements[0]);

                ObservableCollection<Sale> sales = new ObservableCollection<Sale>();



                stores.Add(
                    new Store()
                    {
                        Stor_id = storId,
                        Stor_name = elements[1],
                        Stor_address = elements[2],
                        City = elements[3],
                        State = elements[4],
                        Zip = elements[5],
                        LijstSale = GetSalesByStoreid(storId)
                    }
                );
            }

            return stores;
        }
    }
}
