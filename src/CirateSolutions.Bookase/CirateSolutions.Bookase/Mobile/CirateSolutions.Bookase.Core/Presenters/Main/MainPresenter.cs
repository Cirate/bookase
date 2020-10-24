using CirateSolutions.Bookase.Core.Presenters.Main.Interfaces;
using CirateSolutions.Bookase.MVP;

namespace CirateSolutions.Bookase.Core.Presenters.Main
{
    public class MainPresenter : Presenter<IMainView>, IMainPresenter
    {
        private int _count;

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
    }
}