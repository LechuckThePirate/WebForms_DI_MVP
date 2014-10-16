namespace ITCR.Presenters.Interfaces.ViewModels
{
    public interface IRoleViewModel : IViewModel
    {
        string NewDescription { get; set; }

        void RolesGridDataBind();
        
    }
}
