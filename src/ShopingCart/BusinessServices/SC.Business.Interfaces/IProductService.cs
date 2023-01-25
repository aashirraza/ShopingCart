using SC.Business.Model;


namespace SC.Business.Interfaces
{
    public interface IProductServices
    {
        public List<ProductModel> GetAll();
        public List<ProductModel> Search(string searchTerm);
        public void Add(ProductModel model);
        public void Update(ProductModel model);
        public void Delete(int id);

    }
}
