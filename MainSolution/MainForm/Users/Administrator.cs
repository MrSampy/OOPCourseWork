using MainForm.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new MenuItem("Change the status of the order"),
                new MenuItem("Cancellation by admin"),
            });

        }
    }
}
