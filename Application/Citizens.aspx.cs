using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ITCR.Domain.Entities;
using ITCR.Presenters.Interfaces.Presenters;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Application
{
    public partial class Citizens : System.Web.UI.Page, ICitizenViewModel
    {
        public const string CUSTOMEDIT_CMD = "CustomEdit";

        private ICitizenPresenter _presenter;

        public Citizens()
        {
            _presenter = Injector.Current.Resolve<ICitizenPresenter>();
            _presenter.SetViewModel(this);
        }

        public void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        #region Add Citizen Fields

        public string NewName
        {
            get { return txtNewName.Text; }
            set { txtNewName.Text = value; }
        }

        public Specie NewSpecie
        {
            get { return new Specie { SpecieId = Guid.Parse(ddlNewSpecie.SelectedValue) }; }
            set { ddlNewSpecie.SelectedValue = value.SpecieId.ToString(); }
        }

        public Role NewRole
        {
            get { return new Role { RoleId = Guid.Parse(ddlNewRole.SelectedValue) }; }
            set { ddlNewRole.SelectedValue = value.RoleId.ToString(); }
        }

        public StatusEnum NewStatus
        {
            get { return (StatusEnum)Enum.Parse(typeof(StatusEnum), ddlNewStatus.SelectedValue); }
            set { ddlNewStatus.SelectedValue = value.ToString(); }
        }

        #endregion

        #region Update Citizen fields

        public Guid UpdateCitizenId
        {
            get { return Guid.Parse(hidUpdateCitizenId.Value); }
            set { hidUpdateCitizenId.Value = value.ToString(); }
        }

        public string UpdateName
        {
            get { return txtUpdateName.Text; }
            set { txtUpdateName.Text = value; }
        }

        public Specie UpdateSpecie
        {
            get { return new Specie { SpecieId = Guid.Parse(ddlUpdateSpecie.SelectedValue) }; }
            set { ddlUpdateSpecie.SelectedValue = value.SpecieId.ToString(); }
        }

        public Role UpdateRole
        {
            get { return new Role { RoleId = Guid.Parse(ddlUpdateRole.SelectedValue) }; }
            set { ddlUpdateRole.SelectedValue = value.RoleId.ToString(); }
        }

        public StatusEnum UpdateStatus
        {
            get { return (StatusEnum)Enum.Parse(typeof(StatusEnum), ddlUpdateStatus.SelectedValue); }
            set { ddlUpdateStatus.SelectedValue = value.ToString(); }
        }

        #endregion

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
            pnlError.Visible = true;
        }

        public void BlockUI()
        {
            var cookie = new HttpCookie("blockui") {Expires = DateTime.Now.AddHours(1)};
            Response.Cookies.Add(cookie);
        }

        #region Grid Commands

        public IQueryable<Citizen> CitizensGridGetRows()
        {
            return _presenter.CitizensGridGetRows();
        }

        public void CitizensGridDelete(Guid citizenId)
        {
            _presenter.CitizensGridDelete(citizenId);
        }

        public void CitizensGridDataBind()
        {
            CitizensGrid.DataBind();
        }

        protected void CitizensGrid_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == CUSTOMEDIT_CMD)
                _presenter.CitizenEdit(Guid.Parse(e.CommandArgument.ToString()));
        }
        
        #endregion

        #region Panels

        public void ShowUpdatePanel()
        {
            pnlUpdate.Visible = true;
        }

        public void HideUpdatePanel()
        {
            pnlUpdate.Visible = false;
        }

        public void HideAddPanel()
        {
            pnlAdd.Visible = false;
        }

        public void ShowAddPanel()
        {
            pnlAdd.Visible = true;
        }

        #endregion

        #region Combos

        public IQueryable<Specie> GetSpeciesCombo()
        {
            return _presenter.GetSpeciesCombo();
        }

        public IQueryable<Role> GetRolesCombo()
        {
            return _presenter.GetRolesCombo();
        }

        public IQueryable<object> GetStatusCombo()
        {
            return _presenter.GetStatusCombo();
        }

        #endregion

        #region Buttons

        public void btnUpdateCitizen_Click(object sender, EventArgs e)
        {
            _presenter.UpdateButtonClick();
        }

        public void btnAddCitizen_Click(object sender, EventArgs e)
        {
            _presenter.AddNewButtonClick();
        }

        public void btnCancelUpdateCitizen_Click(object sender, EventArgs e)
        {
            _presenter.CancelUpdateButtonClick();
        }

        #endregion
    }
}