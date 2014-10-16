using System;
using System.Linq;
using ITCR.Domain.Entities;
using ITCR.Domain.Exceptions;
using ITCR.Presenters.Interfaces.Presenters;
using ITCR.Data.Interfaces;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Presenters.Classes
{
    public class RolePresenter : Presenter<IRoleViewModel>, IRolePresenter
    {
        private IRoleService _service;
        public IQueryable<Role> RolesGridGetRows()
        {
            IQueryable<Role> result = null;
            try
            {
                result = _service.GetAllRoles();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex,false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
            return result;
        }

        public void AddNewButtonClick()
        {
            try
            {
                _service.AddRole(_viewModel.NewDescription);
                _viewModel.RolesGridDataBind();
                _viewModel.NewDescription = string.Empty;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex, false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public void RolesGridDelete(Guid id)
        {
            try
            {
                _service.DeleteRole(id);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex, false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public void RolesGridUpdate(Guid id, string description)
        {
            try
            {
                _service.UpdateRole(id, description);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex, false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public RolePresenter(IRoleService service)
        {
            _service = service;
        }

    }
}
