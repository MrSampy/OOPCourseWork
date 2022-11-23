using MainForm.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Repositories
{
    internal class UserRepository
    {
        private List<User> Users;

        public UserRepository() => Users = new List<User>();
        public UserRepository(List<User> users) => Users = users;
    }
}
