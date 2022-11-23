using MainForm.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Repositories
{
    internal class OrderRepository
    {
        private List<Order> Orders;

        public OrderRepository() => Orders = new List<Order>();
        public OrderRepository(List<Order> orders) => Orders = orders;
    }
}
