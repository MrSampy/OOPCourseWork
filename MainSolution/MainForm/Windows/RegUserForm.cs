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
    public partial class RegUserForm : Form
    {
        MyDelegateTwoItem myDelegateTwoItem;
        public RegUserForm(string text, MyDelegateTwoItem myDelegateTwoItem)
        {
            InitializeComponent();
            button1.Text = text;
            this.myDelegateTwoItem = myDelegateTwoItem;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDelegateTwoItem(textBox1.Text, textBox2.Text);
            this.Close();
        }
    }
}
