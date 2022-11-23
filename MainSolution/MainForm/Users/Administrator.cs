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
        }
    }
}
