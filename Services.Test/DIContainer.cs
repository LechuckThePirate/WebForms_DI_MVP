using ITCR.Data.Interfaces;
using ITCR.Data.Mocks.Repositories;
using ITCR.Services.Classes;
using ITCR.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace Services.Test
{
    public class DIContainer
    {
        UnityContainer _container;
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public DIContainer() {
            _container = new UnityContainer();
            _container.RegisterType<IDataContext, ITCR.Data.Mocks.DataContext>();

            _container.RegisterType<IDALContext, ITCR.Data.Mocks.DALContext>();

            _container.RegisterType<ICitizenRepository, CitizenRepository>();
            _container.RegisterType<IRoleRepository, RoleRepository>();
            _container.RegisterType<ISpecieRepository, SpecieRepository>();

            _container.RegisterType<ICitizenService, CitizenService>();
            _container.RegisterType<ISpecieService, SpecieService>();
            _container.RegisterType<IRoleService, RoleService>();
        }
    }
}
