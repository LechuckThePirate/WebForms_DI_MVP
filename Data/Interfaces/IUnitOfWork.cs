using System;

namespace ITCR.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }

}
