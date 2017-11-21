using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefDataGrid
{
    class Store : INotifyPropertyChanged, ICloneable
    {
        #region Fields
        private string _city;
        private ObservableCollection<Sale> _lijstSale;
        private string _state;
        private string _stor_address;
        private int _stor_id;
        private string _stor_name;
        private string _zip;
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion

        #region Constructors
        public Store(string city, string state, string stor_address, int stor_id, string stor_name, string zip, ObservableCollection<Sale> lijstSale)
        {
            City = city;
            State = state;
            Stor_address = stor_address;
            Stor_id = stor_id;
            Stor_name = stor_name;
            Zip = zip;
            LijstSale = lijstSale;
        }

        public Store() : this("", "", "", 0, "", "", null) { }
        #endregion

        #region Properties
        public string City { get => _city; set => _city = value; }
        public string State { get => _state; set => _state = value; }
        public string Stor_address { get => _stor_address; set => _stor_address = value; }
        public int Stor_id { get => _stor_id; set => _stor_id = value; }
        public string Stor_name { get => _stor_name; set => _stor_name = value; }
        public string Zip { get => _zip; set => _zip = value; }
        internal ObservableCollection<Sale> LijstSale { get => _lijstSale; set => _lijstSale = value; }

        public string FormattedTotaal { get => Totaal().ToString("c"); }
        public string Details { get => string.Format("{0}\n{1}\nTotaal: {2}", Stor_address, City, FormattedTotaal); }
        #endregion

        #region Methods
        public double Totaal()
        {
            double totaal = 0;
            foreach (Sale sale in LijstSale)
            {
                totaal += sale.SubTotaal;
            }
            return totaal;
        }
        #endregion

        #region ICloneable
        public object Clone() => this;
        #endregion
    }
}
