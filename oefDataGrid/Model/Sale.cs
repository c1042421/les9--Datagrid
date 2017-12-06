using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace oefDataGrid
{
    class Sale : INotifyPropertyChanged, IEditableObject, ICloneable, IDataErrorInfo
    {
        #region Fields
        private Sale _backup;
        private Book _book;
        private DateTime _ord_date;
        private string _ord_num;
        private string _payterms;
        private int _qty;
        private int _stor_id;
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion

        #region Constructors
        public Sale(int stor_id, string ord_num, DateTime ord_date, int qty, string payterms, Book book)
        {
            Stor_id = stor_id;
            Ord_num = ord_num;
            Ord_date = ord_date;
            Qty = qty;
            Payterms = payterms;
            Book = book;
        }

        public Sale(int stor_id, string ord_num, int qty, string payterms, Book book) : this(stor_id, ord_num, DateTime.Now.Date, qty, payterms, book) { }

        public Sale() : this(0, "", 0, "", null) { }

        #endregion

        #region Properties
        public DateTime Ord_date
        {
            get => _ord_date;
            set
            {
                _ord_date = value;
                RaisePropertyChanged("Ord_date");
            }
        }
        public string Ord_num
        {
            get => _ord_num;
            set
            {
                _ord_num = value;
                RaisePropertyChanged("Ord_num");
            }
        }
        public int Stor_id
        {
            get => _stor_id; set
            {
                _stor_id = value;
                RaisePropertyChanged("Stor_id");
            }
        }
        public Book Book
        {
            get => _book; set
            {
                _book = value;
                RaisePropertyChanged("Book");
            }
        }

        public string Payterms
        {
            get => _payterms; set
            {
                _payterms = value;
                RaisePropertyChanged("Payterms");
            }
        }
        public int Qty
        {
            get => _qty; set
            {
                _qty = value;
                RaisePropertyChanged("Qty");
            }
        }
        public string FormattedTotaal { get => SubTotaal.ToString("c"); }
        public double SubTotaal => Book != null ? Qty * Book.Price : 0;
        #endregion

        #region IEditableObject
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
        #endregion

        #region IClonable
        public object Clone()
        {
            Sale self = (Sale)MemberwiseClone();
            self.Book = (Book)self.Book.Clone();
            return self;
        }
        #endregion

        #region IDataErrorInfo
        public bool IsValid() => string.IsNullOrEmpty(Error);

        public string Error
        {
            get
            {
                string result = "";
                string error = "";

                foreach (var item in GetType().GetProperties())
                {
                    error = this[item.Name];

                    if (!string.IsNullOrEmpty(error))
                    {
                        result += error + Environment.NewLine;
                    }
                }
                return result;
            }
        }

        public string this[string columnName]
        {
            get
            {
                Dictionary<string, Tuple<bool, string>> error = new Dictionary<string, Tuple<bool, string>>();
               
                error.Add("Book", new Tuple<bool, string>(Book == null, "Book is null!"));
                error.Add("Ord_num", new Tuple<bool, string>(string.IsNullOrEmpty(Ord_num), "Order number is empty!"));
                error.Add("Qty", new Tuple<bool, string>(Qty < 0, "Qty is below 0!"));
                error.Add("Stor_id", new Tuple<bool, string>(Stor_id < 0, "Stor_id moet groter zijn dan 0!"));

                string errorMessage = null;

                if (error.ContainsKey(columnName))
                {
                   bool columnIsNotValid = error[columnName].Item1;
                   if (columnIsNotValid) { errorMessage = error[columnName].Item2; }
                }
                return errorMessage;
            }
        }
        #endregion

        #region Overrides
        public override string ToString() => Stor_id + " " + Ord_num;

        public override bool Equals(object obj)
        {
            var sale = obj as Sale;
            return sale != null &&
                   Book.Equals(sale.Book) && Ord_num == sale.Ord_num;
        }

        public override int GetHashCode()
        {
            var hashCode = -1637221800;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ord_num);
            hashCode = hashCode * -1521134295 + Stor_id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Book>.Default.GetHashCode(Book);
            return hashCode;
        }
        #endregion
    }
}
