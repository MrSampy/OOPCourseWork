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
namespace MainForm.Windows.FormTables
{
    internal partial class ProductsInOrderTable : Form
    {
        public ProductsInOrderTable(List<(int, Product)> products)
        {
            InitializeComponent();
            var columnCollection = new string[] { "Product", "Quantity", "Full Cost" };
            for (var i = 0; i < columnCollection.Length; ++i)
                dataGridView1.Columns.Add($"column-{i + 1}", columnCollection[i]);
            foreach (var product in products)
            {
                dataGridView1.Rows.Add(product.Item2.Name,product.Item1,product.Item1*product.Item2.Cost);
            }
        }
    }
}
