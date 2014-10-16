using System;
using System.Linq;
using ITCR.Domain.Entities;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Presenters.Interfaces.Presenters
{
    public interface ISpeciePresenter : IPresenter<ISpecieViewModel>
    {
        IQueryable<Specie> SpeciesGridGetRows();
        void SpeciesGridDelete(Guid id);
        void SpeciesGridUpdate(Guid id, string description);
        void BtnAddSpecieClick();
    }
}
