using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbSample.Infastructure
{
    public interface IBaseRepository<T>
    {
        Task Add(T employee);
        Task Update(T employee);
        Task Delete(string id);
        Task<T> GetById(string id);
        Task<List<T>> Get();
    }
}
