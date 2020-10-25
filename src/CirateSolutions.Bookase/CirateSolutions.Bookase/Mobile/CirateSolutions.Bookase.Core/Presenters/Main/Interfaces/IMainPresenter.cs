using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.Core.Presenters.Main.Interfaces
{
    public interface IMainPresenter
        : IPresenter<IMainView>
    {
        void OnButtonClicked();
        void NavigateToDetails();
    }
}