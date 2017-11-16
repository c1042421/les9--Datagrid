using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefDataGrid
{
    class Sale: INotifyPropertyChanged, IEditableObject, ICloneable
    {
        private Sale _backup;
        private Book _book;
        private DateTime _ord_date;
        private string _ord_num;
        private string _payterms;
        private int _qty;
        private int _stor_id;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
       
        public Sale(int stor_id, string ord_num, DateTime ord_date, int qty, string payterms, Book book)
        {
            Stor_id = stor_id;
            Ord_num = ord_num;
            Ord_date = ord_date;
            Qty = qty;
            Payterms = payterms;
            Book = book;
        }

        public Sale(int stor_id, string ord_num, int qty, string payterms, Book book): this(stor_id,ord_num,DateTime.Now.Date,qty,payterms,book) { }

        public Sale() : this(0, "", 0, "", null) { }

        public DateTime Ord_date { get => _ord_date; set => _ord_date = value; }
        public string Ord_num { get => _ord_num; set => _ord_num = value; }
        public string Payterms { get => _payterms; set => _payterms = value; }
        public int Qty { get => _qty; set => _qty = value; }
        public int Stor_id { get => _stor_id; set => _stor_id = value; }
        internal Book Book { get => _book; set => _book = value; }

        public string FormattedTotaal { get => SubTotaal.ToString("c"); }

        public override string ToString() => "";

        public void BeginEdit()
        {
            _backup = this;
        }

        public void EndEdit()
        {
            _backup = null;
        }

        public void CancelEdit()
        {
            Ord_date = _backup.Ord_date;
            Ord_num = _backup.Ord_num;
            Payterms = _backup.Payterms;
            Qty = _backup.Qty;
            Stor_id = _backup.Stor_id;
            Book = _backup.Book;
        }

        public object Clone() => this;
        
        public double SubTotaal => Qty * Book.Price;
        
    }
}
