using MainForm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainForm.ShopExceptions;
using MainForm.Users;
using MainForm.Windows;
using MainForm.Products;
using System.Xml.Linq;

namespace MainForm.Logic
{
    internal class BusinessLogic
    {
        public UnitOfWork UnitOfWork { set; get; }

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

        public void CreateProduct() 
        {
            var name = string.Empty;
            var category = string.Empty;
            var desc = string.Empty;
            var stringPrice = string.Empty;
            var dialog = new ProductCreator(new MyDelegateFourItem((string data1, string data2, string data3, string data4) => 
            {
                name = data1;
                category = data2;
                desc = data3;
                stringPrice = data4;
            
            }));
            dialog.ShowDialog();
            CheckString(name);
            CheckString(category);
            CheckString(desc);
            CheckString(stringPrice);
            if (UnitOfWork.Products.GetProductByName(name).Count != 0)
            
                throw new MarketException("There have been already product with such name");
            double price = 0;
            try
            {
                price = Convert.ToDouble(stringPrice);
            }
            catch 
            {
                throw new MarketException("Invalid data!");
            }
            UnitOfWork.Products.AddProduct(new Product(name,category,desc,price));

        }

        public void CreateNewOrder(string userName)
        {
           
            var productsInOrder = new List<(int, Product)>();
            
            
            while (true) 
            {
                var productName = string.Empty;
                int productNumber = 0;
                var table1 = new ProductTable(UnitOfWork.Products.GetAllProducts(), new MyDelegateOneItem<string>((string data) => productName = data));
                table1.ShowDialog();
                var table2 = new EnterNumber($"How many {productName} batches, you want to buy?",new MyDelegateOneItem<int>((int data) => productNumber = data));
                table2.ShowDialog();
                if (CheckChoice($"Do you want to add {productNumber} batche(s) of {productName} to order?"))
                    productsInOrder.Add((productNumber,UnitOfWork.Products.GetProductByName(productName).First()));
                if (CheckChoice("Do you want to stop ordering?"))
                    break;
            }
            if (productsInOrder.Count == 0)
                throw new MarketException("Order didn`t created, because you hadn`t chosen any product!");
            UnitOfWork.Orders.AddOrder(userName, productsInOrder);
        }
        public void ChangePersonalInfoOfUser()
        {
            var userName = string.Empty;
            var newProfile = string.Empty;
            var dialog = new CustomDialogBox("Enter user name:", new MyDelegateOneItem<string>((string data) => userName = data));
            dialog.ShowDialog();
            var dialog1 = new CustomDialogBox("Enter new profile information:", new MyDelegateOneItem<string>((string data) => newProfile = data));
            dialog1.ShowDialog();
            var result = UnitOfWork.GetAllUsers().Where(x=>x.NickName.Equals(userName));
            if (result.Count() == 0) 
                throw new MarketException("There is no user with such name!");
            CheckString(newProfile);
            if (!CheckChoice($"Are you really want to change personal info of {result.First().NickName}\n" +
                $"from `{result.First().ProfileInfo}` to `{newProfile}`"))
                return;
            result.First().ChangeProfile(newProfile);

        }
        public void ChangeProductDesc()
        {
            string productName = String.Empty;
            string newDesc = String.Empty;
            var dialog = new CustomDialogBox("Enter product name, you want to change description:", new MyDelegateOneItem<string>((string data) => productName = data));
            dialog.ShowDialog();
            var dialog1 = new CustomDialogBox("Enter new description for product:", new MyDelegateOneItem<string>((string data) => newDesc = data));
            dialog1.ShowDialog();
            var result = UnitOfWork.Products.GetProductByName(productName);
            if (result.Count == 0)   
                throw new MarketException("There is no product with such name");
            CheckString(newDesc);
            if (!CheckChoice($"Are you really want to change description of\n" +
                $" {result.First().Name} from `{result.First().Description}` to `{newDesc}`"))
                return;
            result.First().Description = newDesc;

        }

        public string ChangeProfile(Person person) 
        {
            var user = GetUserByName(person.GetName());
            var newProfile = string.Empty;
            var dialog = new CustomDialogBox("Enter new profile information:", new MyDelegateOneItem<string>((string data) => newProfile = data));
            dialog.ShowDialog();
            CheckString(newProfile);
            if (!CheckChoice($"Are you really want to change your profile information from\n`{user.ProfileInfo}` to `{newProfile}`?"))
                return user.ProfileInfo;
            UnitOfWork.GetAllUsers().First(x => x.NickName.Equals(user.NickName) && x.Password.Equals(user.Password)).ProfileInfo = newProfile;
            return newProfile;
        }

        public void ShowAllProducts() 
        {
            var table = new ProductTable(UnitOfWork.Products.GetAllProducts());
            table.ShowDialog();
        }
        public void ShowAllUsers()
        {
            var table = new UserTable(UnitOfWork.GetAllUsers());
            table.ShowDialog();
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
                throw new MarketException("There is no product with such name");
            var table  = new ProductTable(result);
            table.ShowDialog();

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
