using SC.Business.Interfaces;
using SC.Business.Model;
using SC.Data;
using SC.Data.Interfaces;
using SC.Data.Model;

namespace SC.Business.DataServices
{
    public class ProductServices : IProductServices
    {
        private readonly IRepository<product> _dbContext;
       
        public ProductServices(IRepository<product> dbContext ) 
        {
            _dbContext = dbContext;
        }    

        public List<ProductModel> GetAll()
        {
            var allProducts = _dbContext.GetAll();
            var productModels = allProducts.Select(x => new ProductModel { Id = x.Id, Name = x.Name,
                                                                        Catagory = x.Catagory,
                                                                        Company = x.Company, 
                                                                        Description = x.Description }).ToList();
            return productModels;
        }
        public List<ProductModel> Search(string searchTerm)
        {
            searchTerm = searchTerm.Trim().ToLower();
            var allProducts = _dbContext.Get(x => x.Name.ToLower()
                .Contains(searchTerm) || x.Catagory.ToLower()
                .Contains(searchTerm) || x.Company.ToLower()
                .Contains(searchTerm)).ToList();
            var productModels = allProducts.Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Catagory = x.Catagory,
                Company = x.Company,
                Description = x.Description
            }).ToList();
            return productModels;
        }

        public void Add(ProductModel model)
        {
            _dbContext.Save(new Data.Model.product { Id = model.Id, Name = model.Name, Catagory = model.Catagory, Company = model.Company, Description = model.Description });
           
        }

        public void Update(ProductModel model)
        {
            _dbContext.Save(new product { Id = model.Id, Name = model.Name, Catagory = model.Catagory, Company = model.Company, Description = model.Description });
           
        }
        public void Delete(int id)
        {
            var productToDelete = _dbContext.Get(x => x.Id == id).FirstOrDefault();
            if (productToDelete != null)
            {
                _dbContext.Delete(productToDelete);
                
            }
          
        }

        
    }
}