using MainForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Products
{
    internal class Product: BaseEntity
    {
        public string Name { get; }
        public string Category { get; }
        public string Description { get; set; }
        public double Cost { get; }

        public Product(string name, string category, string description, double cost)
        {
            Name = name;
            Category = category;
            Description = description;
            Cost = cost;
        }

        public override string ToString() => $"{Name}.{Category}.{Cost}";


    }
}
