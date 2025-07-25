using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public class OwnerRepository : GenericRepository<Owners>, IOwnerRepository
    {
        public OwnerRepository(DataContext context) : base(context)
        {

        }
    }
    
        
    
}
