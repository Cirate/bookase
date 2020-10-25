using System;
using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.MVP
{
    public abstract class Presenter<TView> : IPresenter<TView> where TView : class, IView
    {
        public TView View { get; private set; }
        public Type ViewType => typeof(TView);
        public void SetView(TView view) => View = view;
        public virtual void OnViewCreated() {}
        public virtual void OnViewDestroyed() {}

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                SetView(null);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}