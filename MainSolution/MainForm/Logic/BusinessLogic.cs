﻿using MainForm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainForm.ShopExceptions;
using MainForm.Users;
using MainForm.Windows;
using System.Xml.Linq;

namespace MainForm.Logic
{
    internal class BusinessLogic
    {
        public UnitOfWork UnitOfWork { set; get; }
        ProductTable? Table;

        public BusinessLogic(UnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

        public User GetUserByName(string name) => UnitOfWork.RegUsers.GetUserByName(name).Count !=0 ? UnitOfWork.RegUsers.GetUserByName(name).First() : UnitOfWork.Admins.GetUserByName(name).First();


        public void CheckString(string? data)
        {
            if (data is null || data.Equals(""))
                throw new MarketException("Invalid data!");
        }

        public bool CheckChoice(string question)
        {
            bool result = false;
            var process = new CheckForm(question,new MyDelegateOneItem<bool>((bool data)=>result=data));
            process.ShowDialog();
            return result;
        }


        public string ChangeProfile(Person person) 
        {
            var user = GetUserByName(person.GetName());
            var newProfile = string.Empty;
            var dialog = new CustomDialogBox("Enter new profile information:", new MyDelegateOneItem<string>((string data) => newProfile = data));
            dialog.ShowDialog();
            CheckString(newProfile);
            if (!CheckChoice($"Are you really want to change your profile information from\n{user.ProfileInfo} to {newProfile}?"))
                return user.ProfileInfo;
            UnitOfWork.GetAllUsers().First(x => x.NickName.Equals(user.NickName) && x.Password.Equals(user.Password)).ProfileInfo = newProfile;
            return newProfile;
        }

        public void ShowAllProducts() 
        {
            Table = new ProductTable(UnitOfWork.Products.GetAllProducts());
            Table.ShowDialog();
        }
        public User TryEnter(string? name,string? password)
        {
            CheckString(name);
            CheckString(password);

            var user = UnitOfWork.GetAllUsers().Where(x => x.NickName.Equals(name) && x.Password.Equals(password));
            if (user.Count() == 0)
                throw new MarketException("There is no user with such name and password!");
            return user.First();
        }

        public void SearcForProductByName() 
        {
            string productName = String.Empty;
            var dialog = new CustomDialogBox("Enter product name, you want to find:", new MyDelegateOneItem<string>((string data) => productName = data));
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

            CheckString(name);
            CheckString(password);
            if (name!.Equals("Guest"))
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
