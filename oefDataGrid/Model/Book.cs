using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace oefDataGrid
{
    class Book : ICloneable, IDataErrorInfo
    {
        #region Fields
        private double _price;
        private string _pub_id;
        private string _title;
        private string _title_id;
        private string _type;
        #endregion

        #region Constructors
        public Book(double price, string pub_id, string title, string title_id, string type)
        {
            _price = price;
            _pub_id = pub_id;
            _title = title;
            _title_id = title_id;
            _type = type;
        }

        public Book() : this(0, "", "", "", "")
        {
        }
        #endregion

        #region Properties
        public double Price { get => _price; set => _price = value; }
        public string Pub_id { get => _pub_id; set => _pub_id = value; }
        public string Title_id { get => _title_id; set => _title_id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Type { get => _type; set => _type = value; }
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
                bool PriceIsLessThanZero = columnName == "Price" && Price < 0;
                bool Pub_IdIsEmty = columnName == "Pub_id" && string.IsNullOrEmpty(Pub_id);
                bool TitleIsEmpty = columnName == "Title" && string.IsNullOrEmpty(Title);
                bool TitleIdIsEmpty = columnName == "Title_id" && string.IsNullOrEmpty(Title_id);
                bool TypeIsEmpty = columnName == "Type" && string.IsNullOrEmpty(Type);

                if (TitleIdIsEmpty)
                {
                    return "Title_id moet ingevuld zijn!";
                }

                if (TitleIsEmpty)
                {
                    return "Title moet ingevuld zijn!";
                }

                if (PriceIsLessThanZero)
                {
                    return "Prijs moet groter zijn dan 0!";
                }

                return null;
            }
        }
        #endregion

        #region ICloneable
        public object Clone() => base.MemberwiseClone();
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            var book = obj as Book;
            return book != null &&
                   Pub_id == book.Pub_id &&
                   Title_id == book.Title_id;
        }

        public override int GetHashCode()
        {
            var hashCode = -1867856253;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Pub_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title_id);
            return hashCode;
        }

        public override string ToString() => "";
        #endregion
    }
}
