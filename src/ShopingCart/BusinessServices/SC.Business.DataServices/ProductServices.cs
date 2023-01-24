using SC.Business.Interfaces;
using SC.Business.Model;
using SC.Data;

namespace SC.Business.DataServices
{
    public class ProductServices : IProductServices
    {
        private readonly StoreManagementDbContext _dbContext;
       
        public ProductServices(StoreManagementDbContext dbContext ) 
        {
            _dbContext = dbContext;
        }    

        public List<ProductModel> GetAll()
        {
            var allProducts = _dbContext.Products.ToList();
            var productModels = allProducts.Select(x => new ProductModel { Id = x.Id, Name = x.Name,
                                                                        Catagory = x.Catagory,
                                                                        Company = x.Company, 
                                                                        Description = x.Description }).ToList();
            return productModels;
        }

        public void Add(ProductModel model)
        {
            _dbContext.Products.Add(new Data.Model.product { Id = model.Id, Name = model.Name, Catagory = model.Catagory, Company = model.Company, Description = model.Description });
            _dbContext.SaveChanges();
        }

        public void Update(ProductModel model)
        {
            var entity = _dbContext.Products.FirstOrDefault(x => x.Id == model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Catagory = model.Catagory;
                entity.Company = model.Company;
                entity.Description = model.Description;
                _dbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var productToDelete = _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
            if (productToDelete != null)
            {
                _dbContext.Remove(productToDelete);
                _dbContext.SaveChanges();
            }
          
        }

        
    }
}