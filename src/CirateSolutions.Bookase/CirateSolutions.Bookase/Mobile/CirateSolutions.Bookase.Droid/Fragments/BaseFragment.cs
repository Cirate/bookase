using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using CirateSolutions.Bookase.MVP;
using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.Droid.Fragments
{
    public abstract class BaseFragment :
        Fragment,
        IView
    {
    }

    public abstract class BaseFragment<TPresenter, TView>
        : BaseFragment
        where TPresenter : class, IPresenter<TView>
        where TView : class, IView
    {
        private TPresenter _presenter;

        protected abstract int LayoutId { get; }
        protected View FragmentView { get; private set; }
        protected TPresenter Presenter => _presenter ??= ServiceLocator.Instance.GetPresenter<TPresenter, TView>(this as TView);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            FragmentView = inflater.Inflate(LayoutId, container, false);
            FindViews();
            AttachEvents();
            Presenter.OnViewCreated();
            return FragmentView;
        }

        public override void OnDestroyView()
        {
            DetachEvents();
            ClearFoundViews();
            Presenter.OnViewDestroyed();
            Presenter.Dispose();
            _presenter = null;
            base.OnDestroyView();
        }

        protected virtual void AttachEvents() { }
        protected virtual void DetachEvents() { }
        protected virtual void FindViews() { }
        protected virtual void ClearFoundViews() { }
    }
}