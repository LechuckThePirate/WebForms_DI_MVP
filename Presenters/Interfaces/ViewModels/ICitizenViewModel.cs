using System;
using ITCR.Domain.Entities;

namespace ITCR.Presenters.Interfaces.ViewModels
{
    public interface ICitizenViewModel : IViewModel
    {
        string NewName { get; set; }
        Specie NewSpecie { get; set; }
        Role NewRole { get; set; }
        StatusEnum NewStatus { get; set; }

        Guid UpdateCitizenId { get; set; }
        string UpdateName { get; set; }
        Specie UpdateSpecie { get; set; }
        Role UpdateRole { get; set; }
        StatusEnum UpdateStatus { get; set; }

        void CitizensGridDataBind();

        void ShowUpdatePanel();
        void HideUpdatePanel();

        void HideAddPanel();
        void ShowAddPanel();

        void BlockUI();

    }
}
