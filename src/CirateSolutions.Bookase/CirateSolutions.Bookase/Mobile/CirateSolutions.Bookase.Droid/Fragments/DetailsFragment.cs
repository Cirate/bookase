using System;
using Android.Widget;
using CirateSolutions.Bookase.Core.Presenters.Details.Interfaces;

namespace CirateSolutions.Bookase.Droid.Fragments
{
    public class DetailsFragment : BaseFragment<IDetailsPresenter, IDetailsView>, IDetailsView
    {
        private Button _button;
        protected override int LayoutId => Resource.Layout.Details;

        protected override void FindViews()
        {
            base.FindViews();
            _button = FragmentView.FindViewById<Button>(Resource.Id.myButton);
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
        }

        protected override void DetachEvents()
        {
            _button.Click -= ButtonOnClick;
            base.DetachEvents();
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            ParentFragmentManager.PopBackStack();
        }
    }
}