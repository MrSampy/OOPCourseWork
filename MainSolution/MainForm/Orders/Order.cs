using MainForm.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Orders
{
    public enum OrderStatus
    {
        New,
        Payment_received,
        Sent,
        Received,
        Completed,
        Canceled_by_user,
        Canceled_by_the_administrator
    }

    internal class Order
    {
        public OrderStatus Status { get; set; }
        private readonly List<(int, Product)> _productInOrder;
        public string NameOfOwner { get; }
        public bool PaidByUser { get; set; }
        public Order(string name)
        {
            Status = OrderStatus.New;
            NameOfOwner = name;
            _productInOrder = new List<(int, Product)>();
            PaidByUser = false;
        }
        public void AddProductToOrder(int number, Product product)
        {
            _productInOrder.Add((number, product));
        }
        public double GetTotalPrice() => _productInOrder.Select(x => x.Item2.Cost * x.Item1).Sum();

    }
}
