using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public interface IRepository
    {
        void AddOwner(Owners owners);
        IEnumerable<Owners> GetOwner();
        Owners GetOwner(string id);
        bool OwnerExists(string id);
        void RemoveOwner(Owners owners);
        Task<bool> SaveAllAsync();
        void UpdateOwner(Owners owners);
    }
}