using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainForm.Products;
using MainForm.Orders;
using MainForm.Users;

namespace MainForm.Repositories
{
    internal class UnitOfWork
    {
        public ProductRepository Products { get; set; }
        public UserRepository RegUsers { get; set; }
        public UserRepository Admins { get; set; }
        public OrderRepository Orders { get; set; }

        public UnitOfWork(List<Product>? products,List<User>? regUsers, List<User>? admins, List<Order>? orders){
            Products = new ProductRepository(products??new List<Product>());
            RegUsers = new UserRepository(regUsers??new List<User>());
            Admins = new UserRepository(admins ?? new List<User>());
            Orders = new OrderRepository(orders ?? new List<Order>());
        }

        public List<User> GetAllUsers() 
        {
            var result = new List<User>();
            result.AddRange(RegUsers.GetAllUsers());
            result.AddRange(Admins.GetAllUsers());
            return result;
        } 

    }
}
