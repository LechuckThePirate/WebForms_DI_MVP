using ITCR.Domain.Entities;
using ITCR.Data.Interfaces;
using System.Data.Entity;

namespace ITCR.Data.Repositories
{
    public class CitizenRepository : Repository<Citizen>, ICitizenRepository 
    {
        protected override IDbSet<Citizen> DbSet
        {
            get { return Context.Citizens; }
        }

        public CitizenRepository(IDataContext context) : base(context) { }
    }
}
