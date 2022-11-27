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
    public partial class CheckForm : Form
    {
        MyDelegateOneItem<bool> Delegate;
        public CheckForm(string question, MyDelegateOneItem<bool> del)
        {
            InitializeComponent();
            Delegate = del;
            label1.Text = question;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delegate(true);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delegate(false);
            this.Close();
        }
    }
}
