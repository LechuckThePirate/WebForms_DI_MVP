using ITCR.Data.Interfaces;
using System;
using ITCR.Data.Mocks.Repositories;

namespace ITCR.Data.Mocks
{
    public class DALContext : IDALContext
    {
        private ICitizenRepository _citizens;
        private ISpecieRepository _species;
        private IRoleRepository _roles;

        public ICitizenRepository Citizens
        {
            get
            {
                if (_citizens == null)
                    _citizens = new CitizenRepository(null);
                return _citizens;
            }
        }

        public ISpecieRepository Species
        {
            get
            {
                if (_species == null)
                    _species = new SpecieRepository(null);
                return _species;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (_roles == null)
                    _roles = new RoleRepository(null);
                return _roles;
            }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
