using System;
using System.Threading.Tasks;
using CirateSolutions.Bookase.MVP.Interfaces;
using SimpleInjector;

namespace CirateSolutions.Bookase.MVP
{
    public class Bootstrap
    {
        private static bool _bootstrapped;

        public static async Task Init<TBootstrap>() where TBootstrap : Bootstrap
        {
            if (_bootstrapped)
                return;

            _bootstrapped = true;
            var bootstrap = Activator.CreateInstance<TBootstrap>();
            await bootstrap.Init();
        }

        public virtual async Task Init()
        {
            await RegisterDependencies();
        }

        private async Task RegisterDependencies()
        {
            var container = new Container();
            await RegisterDependencies(container);
            container.Verify();
            await SetServiceLocator(container);
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