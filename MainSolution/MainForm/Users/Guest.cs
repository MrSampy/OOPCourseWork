using MainForm.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Users
{
    internal class Guest:Person
    {
        public override string GetName() => "Guest";
        public Guest() 
        {
            MenuItems.AddRange(new List<MenuItem> {
                new MenuItem("Sign in account"),
                new MenuItem("Create new account")
            });
        }
    }
}
