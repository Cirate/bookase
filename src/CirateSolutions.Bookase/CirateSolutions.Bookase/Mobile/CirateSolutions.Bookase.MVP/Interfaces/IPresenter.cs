using System;

namespace CirateSolutions.Bookase.MVP.Interfaces
{
    public interface IPresenter : IDisposable
    {
        public Type ViewType { get; }
        public void OnViewCreated();
        public void OnViewDestroyed();
    }

    public interface IPresenter<TView> : IPresenter
        where TView : IView
    {
        public TView View { get; }
        public void SetView(TView view);
    }
}