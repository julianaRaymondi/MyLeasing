using Microsoft.AspNetCore.Razor.Language.Extensions;
using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        //metodo que dar todos os owners
        public IEnumerable<Owners> GetOwner()
        {

            return _context.Owners.OrderBy(p => p.OwnerName);

        }

        public Owners GetOwner(string id)
        {
            return _context.Owners.Find(id);
        }

        public void AddOwner(Owners owners)
        {
            _context.Owners.Add(owners);
        }

        public void UpdateOwner(Owners owners)
        {
            _context.Owners.Update(owners);
        }
        public void RemoveOwner(Owners owners)
        {
            _context.Owners.Remove(owners);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool OwnerExists(string id)
        {
            return _context.Owners.Any(p => p.Document == id);
        }
    }
}
