using AutoMapper;
using SC.Business.Interfaces;
using SC.Data.Interfaces;
using SC.Data.Model;

namespace SC.Business.DataServices
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<TModel> GetAll()
        {
            var allEntity = _repository.GetAll();
            var allModels = _mapper.Map<List<TModel>>(allEntity);
            return allModels;
        }

        public TModel GetById(int id)
        {
            var Entity = _repository.Get(x => x.Id == id).FirstOrDefault();
            var models = _mapper.Map<TModel>(Entity);
            return models;
        }

        public void Add(TModel model)
        {
            var entity= _mapper.Map<TEntity>(model);
            _repository.Save(entity);
        }
        public void Update(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _repository.Save(entity);
        }

        public void Delete(int id)
        {
            var entity = _repository.Get(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _repository.Delete(entity);
            }
        }
  
    }
}
