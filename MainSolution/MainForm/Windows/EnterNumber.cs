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
    public partial class EnterNumber : Form
    {
        MyDelegateOneItem<int> myDelegate;
        public EnterNumber(string text, MyDelegateOneItem<int> myDelegate)
        {
            InitializeComponent();
            label1.Text = text;
            this.myDelegate = myDelegate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDelegate(Convert.ToInt32(numericUpDown1.Value));
            this.Close();
        }
    }
}
