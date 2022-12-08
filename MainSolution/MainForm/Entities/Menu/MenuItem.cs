using MainForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Menu
{
    internal class MenuItem: BaseEntity
    {
        public ToolStripMenuItem Item { set; get; }
        public MenuItem(string text) 
        {
            Item = new ToolStripMenuItem();
            Item.Text = text;
            Item.Name = text.Replace(' ','_');
            Item.Size = new Size(207, 22);
        }

    }
}
