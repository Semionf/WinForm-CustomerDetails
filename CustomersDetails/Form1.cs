using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomersDetails
{
    public partial class Form1 : Form
    {
        Hashtable productList = new Hashtable();
        static string stringConnection = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=DESKTOP-183SD6J\\SQLEXPRESS01";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(stringConnection))
            {
                string queryString = "select ProductID, ProductName,UnitPrice, UnitsInStock from Products";
                //Adapter
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                //Reader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ProductID = reader.GetInt32(0);
                        Product p = new Product(ProductID, reader.GetString(1),reader.GetSqlMoney(2),reader.GetInt16(3));
                        productList.Add(ProductID, p);
                    }
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product p = (Product)productList[Convert.ToInt32(textBox1.Text)];
            
            label1.Text = p.UnitPrice.ToString();
            label2.Text = p.UnitsInStock.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           int count = 0;
            SqlMoney Price = SqlMoney.Parse(textBox2.Text);
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string queryString = "select UnitPrice from Products";
                //Adapter
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                //Reader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SqlMoney UnitPrice = reader.GetSqlMoney(0);
                        if(Price < UnitPrice)
                        {
                            count++;
                        }
                    }
                }

            }
            MessageBox.Show(count.ToString());
        }
    }
}
