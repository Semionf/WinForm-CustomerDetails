using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersDetails
{
    internal class Product
    {
        private int _ProductID;

        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        private string _ProductName;

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        private SqlMoney _UnitPrice;

        public SqlMoney UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        private int _UnitsInStock;

        public int UnitsInStock
        {
            get { return _UnitsInStock; }
            set { _UnitsInStock = value; }
        }


        public Product(int ProductID, string ProductName, SqlMoney UnitPrice, int UnitsInStock)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.UnitPrice = UnitPrice; 
            this.UnitsInStock = UnitsInStock;
        }    
    }
}
