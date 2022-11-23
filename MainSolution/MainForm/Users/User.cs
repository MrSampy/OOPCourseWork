using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MainForm.Users
{
    internal class User:Person
    {
        public string NickName { get; }
        public string Password { get; }
        public string ProfileInfo { get; set; }
        public override string GetName() => $"{NickName}";
        public void ChangeProfile(string newProfile) => ProfileInfo = newProfile;
        public User(string nickName, string password)
        {
            NickName = nickName;
            Password = password;
            ProfileInfo = $"Hi! I`m {NickName}! Welcome to my profile!";
        }

    }
}
