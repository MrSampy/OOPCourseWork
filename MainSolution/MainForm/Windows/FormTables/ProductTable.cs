using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainForm.Products;
namespace MainForm
{
    internal partial class ProductTable : Form
    {
        MyDelegateOneItem<string> myDelegate;
        private List<Product> products;
        public ProductTable(List<Product> producs)
        {
            InitializeComponent();
            this.ProductView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductView_CellDoubleClick);
            this.products = producs;
            var columnCollection = new string[] { "Name", "Category", "Cost" };
            for (var i = 0; i < columnCollection.Length; ++i)
                ProductView.Columns.Add($"column-{i + 1}", columnCollection[i]);
            RefreshTable();
        }
        public ProductTable(List<Product> producs,MyDelegateOneItem<string> delegateOneItem)
        {
            InitializeComponent();
            this.ProductView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductView_CellDoubleClickDel);
            this.products = producs;
            var columnCollection = new string[] { "Name", "Category", "Cost" };
            for (var i = 0; i < columnCollection.Length; ++i)
                ProductView.Columns.Add($"column-{i + 1}", columnCollection[i]);
            myDelegate = delegateOneItem;
            RefreshTable();
        }
        public void RefreshTable() 
        {
            ProductView.Rows.Clear();

            foreach (var product in products) 
            {
                var data = product.ToString().Split('.');
                ProductView.Rows.Add(data[0], data[1], $"{data[2]}$");
            }

        }
        
        private void ProductView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                MessageBox.Show(products[e.RowIndex].Description);
               
            }

        }
        private void ProductView_CellDoubleClickDel(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                myDelegate(products[e.RowIndex].Name);
                this.Close();
            }
        }
    }
}
