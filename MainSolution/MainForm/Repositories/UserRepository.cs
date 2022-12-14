using MainForm.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Repositories
{
    internal class UserRepository : IRepository
    {
        private List<User> Users;

        public UserRepository() => Users = new List<User>();
        public UserRepository(List<User> users) => Users = users;
        public void AddUser(User user)=>Users.Add(user);
        public List<User> GetAllUsers() => Users;
        public List<User> GetUserByName(string name) => Users.Where(x=>x.NickName.Equals(name)).ToList();
    }
}
