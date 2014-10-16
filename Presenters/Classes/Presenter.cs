using System;
using ITCR.Presenters.Interfaces.Presenters;
using ITCR.Presenters.Interfaces.ViewModels;

namespace ITCR.Presenters.Classes
{
    public class Presenter<TViewModel> : IPresenter<TViewModel> where TViewModel : IViewModel
    {
        protected TViewModel _viewModel { get; set; }

        public void ProcessException(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void SetViewModel(TViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
