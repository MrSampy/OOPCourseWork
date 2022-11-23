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
        }
    }
}
