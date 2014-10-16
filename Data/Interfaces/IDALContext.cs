namespace ITCR.Data.Interfaces
{
    public interface IDALContext : IUnitOfWork
    {
        ICitizenRepository Citizens { get; }
        ISpecieRepository Species { get; }
        IRoleRepository Roles { get; }

    }
}
