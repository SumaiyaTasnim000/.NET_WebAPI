using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID>
    {
        void Add(CLASS entity); 
        void Create(CLASS entity); 
        CLASS Get(ID id);
        List<CLASS> Get();
        void Delete(ID id);
        void Update(CLASS entity);
    }
}
