using MainForm.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Repositories
{
    internal class ProductRepository
    {
        private List<Product> Products;

        public ProductRepository() => Products = new List<Product>();
        public ProductRepository(List<Product> products) => Products = products;

        public List<Product> GetAllProducts() => Products;
        public List<Product> GetProductByName(string name) => Products.Where(x=>x.Name.ToLower().Equals(name.ToLower())).ToList();
    }
}
