using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.MVP
{
    public abstract class Presenter<TView> : IPresenter<TView> where TView : IView
    {
        public TView View { get; private set; }
        public void SetView(TView view) => View = view;
        public virtual void OnViewCreated() {}
    }
}