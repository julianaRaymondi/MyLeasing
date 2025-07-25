using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : class {

            IQueryable<T> GetAll();

            Task<T> GetByIdAsync(string document);

            Task CreateAnsyc(T entity);

            Task UpdateAnsyc(T entity);

            Task DeleteAnsyc(T entity);

            Task<bool> ExistAsync(string id);
        }
    }
}
