using CirateSolutions.Bookase.Core.Presenters.Details.Interfaces;
using CirateSolutions.Bookase.MVP;
using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.Core.Presenters.Details
{
    public class DetailsPresenter : Presenter<IDetailsView>, IDetailsPresenter
    {
        private readonly INavigationService _navigationService;

        public DetailsPresenter(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void GoBack() => _navigationService.Close();
    }
}