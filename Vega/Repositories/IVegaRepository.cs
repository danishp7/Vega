using System.Threading.Tasks;

namespace Vega.Repositories
{
    public interface IVegaRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}