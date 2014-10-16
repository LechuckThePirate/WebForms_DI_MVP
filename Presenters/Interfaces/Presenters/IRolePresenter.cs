using System;
using System.Linq;
using ITCR.Domain.Entities;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Presenters.Interfaces.Presenters
{
    public interface IRolePresenter : IPresenter<IRoleViewModel>
    {
        IQueryable<Role> RolesGridGetRows();
        void AddNewButtonClick();
        void RolesGridDelete(Guid id);
        void RolesGridUpdate(Guid id, string description);
    }
}
