using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainForm.Menu;
namespace MainForm.Users
{
    internal abstract class Person
    {
        public abstract string GetName();
        public List<MenuItem> MenuItems = new()
        {
            new MenuItem("Finish your work"),
            new MenuItem("Search for good by name")
        };
    }
}
