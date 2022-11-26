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
        public RegUserForm(string text, EventHandler action)
        {
            InitializeComponent();
            button1.Text = text;
            button1.Click += new EventHandler(action);

        }

    }
}
