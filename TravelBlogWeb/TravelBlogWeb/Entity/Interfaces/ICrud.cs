using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogWeb.Entity.Interfaces
{
    public interface ICrud<T>
    {
        string Add(T entity);
        T Get(int id);
        List<T> GetAll();
        bool Update(T entity, int id);
        bool Delete(int id);

    }
}
