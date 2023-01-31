using AutoMapper;
using SC.Business.Model;
using SC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Business.DataServices
{
    public class BusinessEntityMappings: Profile
    {
        public BusinessEntityMappings() 
        {
            CreateMap<ProductModel, product>().ReverseMap();
            CreateMap<StoreModel, Store>().ReverseMap();
        }
    }
}
