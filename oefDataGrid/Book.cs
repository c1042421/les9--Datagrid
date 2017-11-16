using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefDataGrid
{
    class Book : ICloneable
    {
        private double _price;
        private string _pub_id;
        private string _title;
        private string _title_id;
        private string _type;

        public Book(double price, string pub_id, string title, string title_id, string type)
        {
            _price = price;
            _pub_id = pub_id;
            _title = title;
            _title_id = title_id;
            _type = type;
        }

        public double Price { get => _price; set => _price = value; }
        public string Pub_id { get => _pub_id; set => _pub_id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Title_id { get => _title_id; set => _title_id = value; }
        public string Type { get => _type; set => _type = value; }

        public override string ToString() => "";

        public object Clone() => (this);
    }
}
