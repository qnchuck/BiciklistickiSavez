using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciklistickiSavez.CRUD
{
    public interface IRepository<T>
    {
        void Create(T entity);
        List<T> GetAll();
        int Delete(int id);

        int Modify(T entity);

    }
}
