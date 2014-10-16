using System;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Presenters.Interfaces.Presenters
{
    public interface IPresenter<in TViewModel> where TViewModel : IViewModel
    {
        // Common stuff
        void ProcessException(Exception ex);

        void SetViewModel(TViewModel viewModel);

    }
}
