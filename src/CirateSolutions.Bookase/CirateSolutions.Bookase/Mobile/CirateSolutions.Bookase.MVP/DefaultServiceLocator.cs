using CirateSolutions.Bookase.MVP.Interfaces;
using SimpleInjector;

namespace CirateSolutions.Bookase.MVP
{
    public class DefaultServiceLocator : IServiceLocator
    {
        private readonly Container _container;

        public DefaultServiceLocator(Container container)
        {
            _container = container;
        }

        public TPresenter GetPresenter<TPresenter, TView>(TView view)
            where TPresenter : class, IPresenter<TView>
            where TView : IView
        {
            var presenter = _container.GetInstance<TPresenter>();
            presenter.SetView(view);
            return presenter;
        }
    }
}