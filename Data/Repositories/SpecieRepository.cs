using ITCR.Domain.Entities;
using ITCR.Data.Interfaces;

namespace ITCR.Data.Repositories
{
    public class SpecieRepository : Repository<Specie>, ISpecieRepository
    {
        protected override System.Data.Entity.IDbSet<Specie> DbSet
        {
            get { return Context.Species; }
        }

        public SpecieRepository(IDataContext context) : base(context) { }

    }
}
