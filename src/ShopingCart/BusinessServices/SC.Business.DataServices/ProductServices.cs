using AutoMapper;
using SC.Business.Interfaces;
using SC.Business.Model;
using SC.Data;
using SC.Data.Interfaces;
using SC.Data.Model;

namespace SC.Business.DataServices
{
    public class ProductServices : GenericService<ProductModel, product>, IProductServices
    {
        private readonly IRepository<product> _repository;
       
        public ProductServices(IRepository<product> repository, IMapper mapper) : base(repository, mapper) 
        {
            _repository = repository;
        }

        public List<ProductModel> ProductsForStore(int StoreId, string? searchTerm)
        {
            

            var productsQurable = _repository.Get(x => x.StoreId == StoreId);

            if (!string.IsNullOrEmpty(searchTerm))
            {
            searchTerm = searchTerm.Trim().ToLower();
                productsQurable = productsQurable.Where(x => x.Name.ToLower()
                .Contains(searchTerm) || x.Catagory.ToLower()
                .Contains(searchTerm) || x.Company.ToLower()
                .Contains(searchTerm));
            }
            var productModels = productsQurable.Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Catagory = x.Catagory,
                Company = x.Company,
                Description = x.Description
            }).ToList();
            return productModels;
        }

        public List<ProductModel> Search(string searchTerm)
        {
            searchTerm = searchTerm.Trim().ToLower();
            var allProducts = _repository.Get(x => x.Name.ToLower()
                .Contains(searchTerm) || x.Catagory.ToLower()
                .Contains(searchTerm) || x.Company.ToLower()
                .Contains(searchTerm)) .ToList();
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

     
        
    }
}