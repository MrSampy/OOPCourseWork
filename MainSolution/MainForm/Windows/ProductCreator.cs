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
namespace MainForm.Windows
{
    public partial class ProductCreator : Form
    {
        MyDelegateFourItem DelegateFourItems;
        public ProductCreator(MyDelegateFourItem del)
        {
            InitializeComponent();
            DelegateFourItems = del;
        }

        private void productPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DelegateFourItems(productName.Text,productCategory.Text,productDesc.Text,productPrice.Text);
            this.Close();
        }


    }
}
