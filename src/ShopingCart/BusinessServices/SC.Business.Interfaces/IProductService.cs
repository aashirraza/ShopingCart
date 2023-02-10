using SC.Business.Model;


namespace SC.Business.Interfaces
{
    public interface IProductServices : IGenericService<ProductModel>
    {
       public List<ProductModel> Search(string searchTerm);
       public List<ProductModel> ProductsForStore(int StoreId, string? searchTerm);
    }
}
