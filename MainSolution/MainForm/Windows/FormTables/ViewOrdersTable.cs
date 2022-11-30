using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainForm.Orders;
using MainForm.Products;

namespace MainForm.Windows.FormTables
{
    internal partial class ViewOrdersTable : Form
    {
        List<Order> orders;
        ProductsInOrderTable table;
        public ViewOrdersTable(List<Order> orders)
        {
            InitializeComponent();
            this.orders = orders;
            var columnCollection = new string[] { "Customer", "Full Cost", "Status" };
            for (var i = 0; i < columnCollection.Length; ++i)
                dataGridView1.Columns.Add($"column-{i + 1}", columnCollection[i]);
            foreach (var order in orders)
            {
                dataGridView1.Rows.Add(order.NameOfOwner,order.GetTotalPrice(),order.Status);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            table = new ProductsInOrderTable(orders[e.RowIndex]._productInOrder);
            table.ShowDialog();
        }
    }
}
