using SC.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Business.DataServices.Interfaces
{
    public interface IProductServices
    {
        public List<ProductModel> GetAll();
        public void Add(ProductModel model);
        public void Delete(int id);

    }
}
