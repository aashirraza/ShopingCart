using SC.Business.DataServices.Interfaces;
using SC.Business.Model;
using System.Security.Cryptography.X509Certificates;

namespace SC.Business.DataServices
{
    public class ProductServices : IProductServices
    {
        private List<ProductModel> products = new List<ProductModel>();

        public List<ProductModel> GetAll()
        {
            products.Add(new ProductModel { Id = 1, Name = "Perfume 1", Catagory = "Men", Company = "Guci", Description = "New arivals" });
            return products;
        }

        public void Add(ProductModel model)
        {
            products.Add(model);
        }

        public void Delete(int id)
        {
            var productToDelete = products.Where(x => x.Id == id).FirstOrDefault();
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
          
        }

    }
}