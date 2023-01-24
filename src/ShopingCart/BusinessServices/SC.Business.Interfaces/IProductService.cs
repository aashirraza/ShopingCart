using SC.Business.Model;


namespace SC.Business.Interfaces
{
    public interface IProductServices
    {
        public List<ProductModel> GetAll();
        public void Add(ProductModel model);
        public void Update(ProductModel model);
        
        public void Delete(int id);

    }
}
