using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm.Windows
{
    public partial class CustomDialogBox : Form
    {
        private MyDelegateOneItem delegateOneItem;
        public CustomDialogBox(string question, MyDelegateOneItem delegateOneItem)
        {
            InitializeComponent();
            label1.Text = question;
            this.delegateOneItem = delegateOneItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delegateOneItem(textBox1.Text);
            this.Close();
        }

    }
}
