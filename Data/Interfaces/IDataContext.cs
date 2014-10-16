using ITCR.Domain.Entities;
using System.Data.Entity;

namespace ITCR.Data.Interfaces
{
    public interface IDataContext :  IDbContext
    {
        IDbSet<Citizen> Citizens { get; }
        IDbSet<Role> Roles { get; }
        IDbSet<Specie> Species { get; }

        void SetModified(object entity);
    }
}
