using AutoMapper;
using SC.Business.Interfaces;
using SC.Business.Model;
using SC.Data.Interfaces;
using SC.Data.Model;

namespace SC.Business.DataServices
{
    public class StoreServices : GenericService<StoreModel, Store>, IStoreServices
    {
        private readonly IRepository<Store> _repository;
       
        public StoreServices(IRepository<Store> repository, IMapper mapper) : base(repository, mapper) 
        {
      
        }    
        
    }
}