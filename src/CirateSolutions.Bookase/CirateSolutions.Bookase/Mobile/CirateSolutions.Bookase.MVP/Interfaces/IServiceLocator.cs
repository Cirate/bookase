namespace CirateSolutions.Bookase.MVP.Interfaces
{
    public interface IServiceLocator
    {
        TPresenter GetPresenter<TPresenter, TView>(TView view)
            where TPresenter : class, IPresenter<TView>
            where TView : IView;
    }
}