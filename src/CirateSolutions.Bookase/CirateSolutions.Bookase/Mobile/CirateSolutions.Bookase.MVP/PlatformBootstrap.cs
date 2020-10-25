using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CirateSolutions.Bookase.MVP.Interfaces;
using SimpleInjector;

namespace CirateSolutions.Bookase.MVP
{
    public class PlatformBootstrap : IPlatformBootstrap
    {
        protected virtual IEnumerable<Assembly> ViewAssemblies => Enumerable.Empty<Assembly>();
        protected virtual IEnumerable<Assembly> PresenterAssemblies => Enumerable.Empty<Assembly>();

        public async Task Init(Container container)
        {
            await RegisterDefaultPlatformDependencies(container);
            await RegisterPlatformDependencies(container);
        }

        private Task RegisterDefaultPlatformDependencies(Container container)
        {
            container.Register<IViewLocator, ViewLocator>();
            container.RegisterInitializer<ViewLocator>(x => x.Build(ViewAssemblies, PresenterAssemblies));
            return Task.CompletedTask;
        }

        public virtual Task RegisterPlatformDependencies(Container container) => Task.CompletedTask;
    }
}