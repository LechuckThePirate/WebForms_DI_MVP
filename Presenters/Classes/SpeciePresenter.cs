using System;
using System.Linq;
using ITCR.Domain.Entities;
using ITCR.Domain.Exceptions;
using ITCR.Presenters.Interfaces.Presenters;
using ITCR.Presenters.Interfaces.ViewModels;
using ITCR.Services.Interfaces;

namespace ITCR.Presenters.Classes
{
    public class SpeciePresenter : Presenter<ISpecieViewModel>, ISpeciePresenter
    {

        private ISpecieService _service;

        public IQueryable<Specie> SpeciesGridGetRows()
        {
            IQueryable<Specie> result = null;
            try
            {
                result = _service.GetAllSpecies();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex,false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
            return result;
        }

        public void SpeciesGridDelete(Guid id)
        {
            try
            {
                _service.DeleteSpecie(id);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex,false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public void SpeciesGridUpdate(Guid id, string description)
        {
            try
            {
                _service.UpdateSpecie(id, description);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex, false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public void BtnAddSpecieClick()
        {
            try
            {
                _service.AddSpecie(_viewModel.NewDescription);
                _viewModel.SpeciesGridDataBind();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex,false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public SpeciePresenter(ISpecieService service)
        {
            _service = service;
        }
    }
}
