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
        OrderStatus status;
        MyDelegateOneItem<int> delegateOneItem;
        string question;

        public ViewOrdersTable(List<Order> orders)
        {
            InitializeComponent();
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick); 
            this.orders = orders;
            var columnCollection = new string[] { "Customer", "Full Cost", "Status" };
            for (var i = 0; i < columnCollection.Length; ++i)
                dataGridView1.Columns.Add($"column-{i + 1}", columnCollection[i]);
            RefreshTable();

        }

        private void RefreshTable() 
        {
            dataGridView1.Rows.Clear();
            foreach (var order in orders)
            {
                dataGridView1.Rows.Add(order.NameOfOwner, order.GetTotalPrice(), order.Status);
            }
        }
        public ViewOrdersTable(List<Order> orders, OrderStatus status, MyDelegateOneItem<int> delegateOneItem, string text)
        {
            InitializeComponent();
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClickChangeStatus);
            this.orders = orders;
            var columnCollection = new string[] { "Customer", "Full Cost", "Status" };
            for (var i = 0; i < columnCollection.Length; ++i)
                dataGridView1.Columns.Add($"column-{i + 1}", columnCollection[i]);
            RefreshTable();
            this.status = status;
            this.delegateOneItem = delegateOneItem;
            question = text;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            table = new ProductsInOrderTable(orders[e.RowIndex]._productInOrder);
            table.ShowDialog();
        }

        private void dataGridView1_CellDoubleClickChangeStatus(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var changeStatus=false;
            var table = new CheckForm(question, new MyDelegateOneItem<bool>((bool data)=>changeStatus=data));
            table.ShowDialog();
            if (!changeStatus)
                return;
            delegateOneItem(e.RowIndex);
            orders[e.RowIndex].Status = status;
            Refresh();
            this.Close();

        }
    }
}
