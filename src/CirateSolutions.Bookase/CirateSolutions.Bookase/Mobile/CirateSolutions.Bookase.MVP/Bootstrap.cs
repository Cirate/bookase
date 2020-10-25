using System;
using System.Linq;
using System.Threading.Tasks;
using CirateSolutions.Bookase.MVP.Interfaces;
using SimpleInjector;
using SimpleInjector.Diagnostics;

namespace CirateSolutions.Bookase.MVP
{
    public abstract class Bootstrap
    {
        private bool _bootstrapped;
        private Container _container;

        public static async Task Init<TBootstrap, TPlatformBootstrap>()
            where TBootstrap : Bootstrap
            where TPlatformBootstrap : PlatformBootstrap
        {
            var bootstrap = Activator.CreateInstance<TBootstrap>();
            var platformBootstrap = Activator.CreateInstance<TPlatformBootstrap>();
            await bootstrap.Init(platformBootstrap);
        }

        protected abstract Type InitialPresenter { get; }

        private async Task Init(IPlatformBootstrap platformBootstrap)
        {
            if (_bootstrapped)
            {
                await NavigateToInitialPresenter();
                return;
            }

            _bootstrapped = true;
            _container = new Container();
            await RegisterDefaultDependencies();
            await platformBootstrap.Init(_container);
            _container.Verify();
            await SetServiceLocator(_container);
            await NavigateToInitialPresenter();
        }

        private async Task NavigateToInitialPresenter()
        {
            var navigationService = _container.GetInstance<INavigationService>();
            await navigationService.Navigate(InitialPresenter, addToBackStack: false);
        }

        private async Task RegisterDefaultDependencies()
        {
            await RegisterDependencies(_container);

            _container
                .GetCurrentRegistrations()
                .Where(x => typeof(IPresenter).IsAssignableFrom(x.ServiceType))
                .Select(x => x.Registration)
                .ToList()
                .ForEach(x => x.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Disposed manually"));
        }

        private async Task SetServiceLocator(Container container)
        {
            var serviceLocator = await CreateServiceLocator(container);
            ServiceLocator.SetImplementation(serviceLocator);
        }

        protected virtual async Task RegisterDependencies(Container container)
        {
        }

        protected virtual async Task<IServiceLocator> CreateServiceLocator(Container container)
        {
            return new DefaultServiceLocator(container);
        }
    }
}