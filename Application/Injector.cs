using System;
using ITCR.Data.Interfaces;
using ITCR.Presenters.Classes;
using ITCR.Presenters.Interfaces.Presenters;
using ITCR.Services.Classes;
using ITCR.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace ITCR.Application
{
    public class Injector : IDisposable
    {

        private UnityContainer _uc;

        private static Injector _current;

        public static Injector Current
        {
            get { return _current ?? (_current = new Injector()); }
        }

        public Injector()
        {
            _uc = new UnityContainer();
        }

        public T Resolve<T>()
        {
            return _uc.Resolve<T>();
        }

        public void Register()
        {
            _uc.RegisterType<IDataContext, ITCR.Data.DataContext>();
            _uc.RegisterType<IDALContext, ITCR.Data.DALContext>();

            _uc.RegisterType<ICitizenRepository, ITCR.Data.Repositories.CitizenRepository>();
            _uc.RegisterType<IRoleRepository, ITCR.Data.Repositories.RoleRepository>();
            _uc.RegisterType<ISpecieRepository, ITCR.Data.Repositories.SpecieRepository>();

            _uc.RegisterType<ICitizenService, CitizenService>();
            _uc.RegisterType<ISpecieService, SpecieService>();
            _uc.RegisterType<IRoleService, RoleService>();

            _uc.RegisterType<IRolePresenter, RolePresenter>();
            _uc.RegisterType<ISpeciePresenter, SpeciePresenter>();
            _uc.RegisterType<ICitizenPresenter, CitizenPresenter>();

        }

        public void Dispose()
        {
            if (_uc != null) _uc.Dispose();
        }
    }
}