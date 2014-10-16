using System;
using System.Linq;
using ITCR.Domain.Entities;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Presenters.Interfaces.Presenters
{
    public interface ICitizenPresenter : IPresenter<ICitizenViewModel>
    {
        IQueryable<Citizen> CitizensGridGetRows();
        void AddNewButtonClick();
        void CitizenEdit(Guid citizenId);
        void CitizensGridDelete(Guid citizenId);
        void UpdateButtonClick();
        IQueryable<Specie> GetSpeciesCombo();
        IQueryable<Role> GetRolesCombo();
        IQueryable<Status> GetStatusCombo();
        void CancelUpdateButtonClick();
    }
}
