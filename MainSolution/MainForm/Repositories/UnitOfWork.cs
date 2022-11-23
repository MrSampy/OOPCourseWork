using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Repositories
{
    internal class UnitOfWork
    {
        public ProductRepository Products { get; set; }
        public UserRepository Admins { get; set; }
        public UserRepository RegUsers { get; set; }
        public OrderRepository Orders { get; set; }
    }
}
