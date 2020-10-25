using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.Core.Presenters.Details.Interfaces
{
    public interface IDetailsPresenter : IPresenter<IDetailsView>
    {
        void GoBack();
    }
}