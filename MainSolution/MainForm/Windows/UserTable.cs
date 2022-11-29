using MainForm.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainForm.Users;
namespace MainForm.Windows
{
    internal partial class UserTable : Form
    {
        private List<User> users;
        public UserTable(List<User> users)
        {
            InitializeComponent();
            this.users= users;
            var columnCollection = new string[] {"Name", "Password", "Profile Info"};
            for (var i = 0; i < columnCollection.Length; ++i)
                UserView.Columns.Add($"column-{i + 1}", columnCollection[i]);
            RefreshTable();
        }
        public void RefreshTable()
        {
            UserView.Rows.Clear();

            foreach (var user in users)
            {         
                UserView.Rows.Add(user.GetName(), user.Password, user.ProfileInfo);
            }

        }
    }
}
