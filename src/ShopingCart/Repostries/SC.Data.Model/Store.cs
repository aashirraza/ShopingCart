using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Data.Model
{
    public class Store : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Catagory { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;


    }
}
