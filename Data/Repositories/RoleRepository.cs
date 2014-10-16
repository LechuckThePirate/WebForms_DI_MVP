using ITCR.Domain.Entities;
using ITCR.Data.Interfaces;

namespace ITCR.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository 
    {

        protected override System.Data.Entity.IDbSet<Role> DbSet
        {
            get { return Context.Roles; }
        }

        public RoleRepository(IDataContext context) : base(context) { }
    }
}
