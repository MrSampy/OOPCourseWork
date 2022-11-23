using MainForm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
