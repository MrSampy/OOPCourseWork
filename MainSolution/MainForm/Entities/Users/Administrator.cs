using MainForm.Menu;
using MainForm.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MainForm.Users
{
    internal class Administrator : User
    {
        public Administrator(string nickName, string password) : base(nickName, password)
        {
            MenuItems.AddRange(new List<MenuItem>
            {
                new MenuItem("View all orders"),
                new MenuItem("Add new product"),
                new MenuItem("Change description about the product"),
                new MenuItem("View personal information of users"),
                new MenuItem("Change personal information of user"),
                new MenuItem("Setting the status of the order Sent"),
                new MenuItem("Setting the status of the order Completed"),
                new MenuItem("Cancellation by admin"),
            });

        }
    }
}
