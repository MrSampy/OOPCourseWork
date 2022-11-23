using MainForm.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Users
{
    internal class RegisteredPerson : User
    {
        public RegisteredPerson(string nickName, string password) : base(nickName, password)
        {
            MenuItems.AddRange(new List<MenuItem>
            {
                new MenuItem("Cancellation"),
                new MenuItem("Review the history of orders"),
                new MenuItem("Setting the status of the order Received")

            });

        }
    }
}
