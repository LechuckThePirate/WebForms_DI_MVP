using System;
using System.Linq;
using ITCR.Domain.Entities;
using ITCR.Presenters.Interfaces.Presenters;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Application
{
    public partial class Species : System.Web.UI.Page, ISpecieViewModel
    {
        private ISpeciePresenter _presenter;

        public Species()
        {
            _presenter = Injector.Current.Resolve<ISpeciePresenter>();
            _presenter.SetViewModel(this);
        }

        public string NewDescription
        {
            get { return txtNewDescription.Text; }
            set { txtNewDescription.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e) { }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
        }

        public void SpeciesGridDataBind()
        {
            SpeciesGrid.DataBind();
        }

        public IQueryable<Specie> SpeciesGridGetRows()
        {
            return _presenter.SpeciesGridGetRows();
        }

        public void SpeciesGridDelete(Guid specieId)
        {
            _presenter.SpeciesGridDelete(specieId);
        }

        public void SpeciesGridUpdate(Guid specieId, string description)
        {
            _presenter.SpeciesGridUpdate(specieId,description);
        }

        public void btnAddSpecie_Click(object sender, EventArgs e)
        {
            _presenter.BtnAddSpecieClick();
        }
    }
}