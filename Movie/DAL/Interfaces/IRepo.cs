using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RET>
    {
        RET Create(CLASS obj); 
        RET Update(CLASS obj); 
        CLASS Get(ID id); // Get a specific entity by ID
        List<CLASS> Get(); // Get all entities
        bool Delete(ID id); 
    }

}
