using ITCR.Data.Interfaces;
using ITCR.Data.Repositories;
using System;

namespace ITCR.Data
{
    /// <summary>
    /// Unit of work with all the repositories. Allows us to isolate database reads and writes for processes
    /// </summary>
    public class DALContext : IDALContext
    {
        private IDataContext _DB;
        private ICitizenRepository _citizens;
        private ISpecieRepository _species;
        private IRoleRepository _roles;

        public DALContext(IDataContext context)
        {
            _DB = context;
        }

        public ICitizenRepository Citizens
        {
            get
            {
                if (_citizens == null)
                    _citizens = new CitizenRepository(_DB);
                return _citizens;
            }
        }

        public ISpecieRepository Species
        {
            get
            {
                if (_species == null)
                    _species = new SpecieRepository(_DB);
                return _species;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (_roles == null)
                    _roles = new RoleRepository(_DB);
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
