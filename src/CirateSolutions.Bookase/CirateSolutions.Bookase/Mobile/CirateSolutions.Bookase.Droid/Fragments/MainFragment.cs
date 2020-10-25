using System;
using Android.Widget;
using CirateSolutions.Bookase.Core.Presenters.Main.Interfaces;

namespace CirateSolutions.Bookase.Droid.Fragments
{
    public class MainFragment : BaseFragment<IMainPresenter, IMainView>, IMainView
    {
        private Button _button;
        private Button _goNextButton;
        protected override int LayoutId => Resource.Layout.Main;

        public void SetButtonText(string text)
        {
            _button.Text = text;
        }

        protected override void FindViews()
        {
            base.FindViews();
            _button = FragmentView.FindViewById<Button>(Resource.Id.myButton);
            _goNextButton = FragmentView.FindViewById<Button>(Resource.Id.GoNextButton);
        }

        protected override void ClearFoundViews()
        {
            base.ClearFoundViews();
            _button = null;
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            _button.Click += ButtonOnClick;
            _goNextButton.Click += ButtonOnClick;
        }

        protected override void DetachEvents()
        {
            _button.Click -= ButtonOnClick;
            _goNextButton.Click -= ButtonOnClick;
            base.DetachEvents();
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            if (sender == _goNextButton)
            {
                Presenter.NavigateToDetails();
            }
            else if (sender == _button)
            {
                Presenter.OnButtonClicked();
            }
        }
    }
}