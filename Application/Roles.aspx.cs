using ITCR.Domain.Entities;
using System;
using System.Linq;
using System.Web.UI;
using ITCR.Presenters.Interfaces.Presenters;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Application
{
    public partial class Roles : Page, IRoleViewModel
    {

        #region Private fields
        private IRolePresenter _presenter = null;
        #endregion

        #region Constructor
        public Roles()
        {
            _presenter = Injector.Current.Resolve<IRolePresenter>();
            _presenter.SetViewModel(this);
        }
        #endregion

        #region Fields and properties
        public string NewDescription
        {
            get { return txtNewDescription.Text; }
            set { txtNewDescription.Text = value; }

        }
        #endregion

        #region Form Events

        public void btnAddRole_Click(object sender, EventArgs e)
        {
            _presenter.AddNewButtonClick();
        }

        public IQueryable<Role> RolesGridGetRows()
        {
            return _presenter.RolesGridGetRows();
        }

        public void RolesGridDelete(Guid roleId)
        {
            _presenter.RolesGridDelete(roleId);
        }

        public void RolesGridUpdate(Guid roleId, string description)
        {
            _presenter.RolesGridUpdate(roleId, description);
        }
        #endregion

        #region Presenter Callbacks
        public void RolesGridDataBind()
        {
            RolesGrid.DataBind();
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
        #endregion

    }
}