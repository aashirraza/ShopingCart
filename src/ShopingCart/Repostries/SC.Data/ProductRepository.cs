using Microsoft.EntityFrameworkCore;
using SC.Data.Interfaces;
using SC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Data
{
    public class ProductRepository : Repository<product>, IProductRepository
    {
        public ProductRepository(StoreManagementDbContext context) : base(context)
        {

        }
    }
}
