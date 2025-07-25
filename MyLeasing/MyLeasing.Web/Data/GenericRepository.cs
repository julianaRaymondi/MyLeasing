using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;
using static MyLeasing.Web.Data.IGenericRepository;

namespace MyLeasing.Web.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;


        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().AsNoTracking()
            .FirstOrDefaultAsync(e => e.Document == id);
        }

        public async Task CreateAnsyc(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveAllAsync();

        }

        public async Task UpdateAnsyc(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAllAsync();
        }
        public async Task DeleteAnsyc(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveAllAsync();

        }
        public async Task<bool> ExistAsync(string id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Document == id);

        }

        private async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() < 0;

        }



    }
}
