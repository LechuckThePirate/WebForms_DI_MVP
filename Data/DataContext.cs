using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;
using System.Data.Entity;

namespace ITCR.Data
{
    /// <summary>
    /// Entity Framekwork's code first implementation of our DataContext
    /// </summary>
    public class DataContext : DbContext, IDataContext
    {
        public virtual IDbSet<Citizen> Citizens { get; set; }
        public virtual IDbSet<Specie> Species { get; set; }
        public virtual IDbSet<Role> Roles { get; set; }

        public DataContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
