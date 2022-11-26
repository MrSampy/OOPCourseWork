using MainForm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainForm.ShopExceptions;
using MainForm.Users;
using MainForm.Windows;

namespace MainForm.Logic
{
    internal class BusinessLogic
    {
        public UnitOfWork UnitOfWork { set; get; }
        ProductTable? Table;

        public BusinessLogic(UnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

        public void ShowAllProducts() 
        {
            Table = new ProductTable(UnitOfWork.Products.GetAllProducts());
            Table.ShowDialog();
        }
        public User TryEnter(string? name,string? password)
        {
            if (name is null || name.Equals("") || password is null || password.Equals("") || name.Equals("Guest"))
                throw new MarketException("Invalid data!");
            var user = UnitOfWork.GetAllUsers().Where(x => x.NickName.Equals(name) && x.Password.Equals(password));
            if (user.Count() == 0)
                throw new MarketException("There is no user with such name and password!");
            return user.First();
        }

        public void SearcForProductByName() 
        {
            string productName = String.Empty;
            var dialog = new CustomDialogBox("Enter product name, you want to find:", new MyDelegateOneItem((string data) => productName = data));
            dialog.ShowDialog();
            var result = UnitOfWork.Products.GetProductByName(productName);
            if (result.Count == 0) 
            {
                MessageBox.Show("There is no product with such name");
                return;
            }
            Table = new ProductTable(result);
            Table.ShowDialog();

        }
        public User TryCreateNewUser(string? name, string? password)
        {
            if (name is null || name.Equals("") || password is null || password.Equals("") || name.Equals("Guest"))
                throw new MarketException("Invalid data!");
            var users = UnitOfWork.GetAllUsers().Where(x => x.NickName.Equals(name));
            if (users.Count() >=1)
                throw new MarketException("There have been already user with such name!");
            var user = new RegisteredPerson(name, password);
            UnitOfWork.RegUsers.AddUser(user);
            return user; 
        }


    }
}
