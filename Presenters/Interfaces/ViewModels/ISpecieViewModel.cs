namespace ITCR.Presenters.Interfaces.ViewModels
{
    public interface ISpecieViewModel : IViewModel
    {
        string NewDescription { get; set; }

        void SpeciesGridDataBind();
    }
}
