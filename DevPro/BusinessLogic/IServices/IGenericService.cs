using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface IGenericService<T> where T : class
    {
        void New(T item);

        void Update(T item);

        bool Delete(T item);

        T GetById(int id);

        IEnumerable<T> GetAllItems();
    }
}
