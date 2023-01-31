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
    public class StoreRepository : Repository<Store>, IStoretRepository
    {
        public StoreRepository(StoreManagementDbContext context) : base(context)
        {

        }
    }
}
