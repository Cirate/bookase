using CirateSolutions.Bookase.Core.Presenters.Details.Interfaces;
using CirateSolutions.Bookase.Core.Presenters.Main.Interfaces;
using CirateSolutions.Bookase.MVP;
using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.Core.Presenters.Main
{
    public class MainPresenter : Presenter<IMainView>, IMainPresenter
    {
        private readonly INavigationService _navigationService;
        private int _count;

        public MainPresenter(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void OnViewCreated()
        {
            base.OnViewCreated();
            if (_count == 0)
                View.SetButtonText("Hello from presenter!");
            else
                View.SetButtonText($"Clicked: {_count}");
        }

        public void OnButtonClicked()
        {
            View.SetButtonText($"Clicked: {++_count}");
        }

        public void NavigateToDetails()
        {
            _navigationService.Navigate<IDetailsPresenter>();
        }
    }
}