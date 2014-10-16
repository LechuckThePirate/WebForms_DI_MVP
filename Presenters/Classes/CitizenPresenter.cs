using System;
using System.Collections.Generic;
using System.Linq;
using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;
using ITCR.Domain.Exceptions;
using ITCR.Presenters.Interfaces.Presenters;
using ITCR.Presenters.Interfaces.ViewModels;
using ITCR.Services.Interfaces;

namespace ITCR.Presenters.Classes
{
    public class CitizenPresenter : Presenter<ICitizenViewModel>, ICitizenPresenter
    {

        // Services
        private ICitizenService _citizenService;
        private IRoleService _roleService;
        private ISpecieService _specieService;

        public CitizenPresenter(ICitizenService citizenService, IRoleService roleService, ISpecieService specieService)
        {
            _citizenService = citizenService;
            _roleService = roleService;
            _specieService = specieService;
        }

        #region Grid Commmands

        public IQueryable<Citizen> CitizensGridGetRows()
        {
            IQueryable<Citizen> result = null;
            try
            {
                result = _citizenService.GetAllCitizens();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex,false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
            return result;
        }

        public void CitizensGridDelete(Guid citizenId)
        {
            try
            {
                _citizenService.DeleteCitizen(citizenId);
                _viewModel.CitizensGridDataBind();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex, false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public void CitizenEdit(Guid citizenId)
        {
            try
            {
                _viewModel.ShowUpdatePanel();
                _viewModel.HideAddPanel();
                var citizen = _citizenService.GetCitizen(citizenId);
                _viewModel.UpdateCitizenId = citizen.CitizenId;
                _viewModel.UpdateName = citizen.Name;
                _viewModel.UpdateSpecie = citizen.Specie;
                _viewModel.UpdateRole = citizen.Role;
                _viewModel.UpdateStatus = citizen.Status;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex, false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Buttons

        public void AddNewButtonClick()
        {
            try
            {
                _citizenService.AddCitizen(_viewModel.NewName, _viewModel.NewSpecie.SpecieId, _viewModel.NewRole.RoleId,
                    _viewModel.NewStatus);
                _viewModel.CitizensGridDataBind();
            }
            catch (SkywalkerAlertException ex)
            {
                _viewModel.BlockUI();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex,false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public void UpdateButtonClick()
        {
            try
            {
                _citizenService.UpdateCitizen(
                    _viewModel.UpdateCitizenId,
                    _viewModel.UpdateName,
                    _viewModel.UpdateSpecie.SpecieId,
                    _viewModel.UpdateRole.RoleId,
                    _viewModel.UpdateStatus);
                _viewModel.CitizensGridDataBind();
                _viewModel.HideUpdatePanel();
                _viewModel.ShowAddPanel();
            }
            catch (SkywalkerAlertException ex)
            {
                _viewModel.BlockUI();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex,false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
        }

        public void CancelUpdateButtonClick()
        {
            _viewModel.HideUpdatePanel();
            _viewModel.ShowAddPanel();
        }

        #endregion

        #region DropDownLists 

        public IQueryable<Specie> GetSpeciesCombo()
        {
            IQueryable<Specie> result = null;
            try
            {
                result = _specieService.GetSpeciesForCombo();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex, false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
            return result;
        }

        public IQueryable<Role> GetRolesCombo()
        {
            IQueryable<Role> result = null;
            try
            {
                result = _roleService.GetRolesForCombo();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex, false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
            return result;
        }

        public IQueryable<Status> GetStatusCombo()
        {
            IQueryable<Status> result = null;
            try
            {
                var items = new List<Status>();
                foreach (var v in Enum.GetValues(typeof (StatusEnum)))
                    items.Add(new Status {statusId = (StatusEnum) v});
                result = items.AsQueryable();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex,false);
                _viewModel.ShowErrorMessage(ex.Message);
            }
            return result;
        }


        #endregion

    }
}
