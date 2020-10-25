using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CirateSolutions.Bookase.Core.Extensions.EnumerableExtensions;
using CirateSolutions.Bookase.Core.Presenters.Main.Interfaces;
using CirateSolutions.Bookase.MVP;
using CirateSolutions.Bookase.MVP.Interfaces;
using SimpleInjector;

namespace CirateSolutions.Bookase.Droid
{
    public class BookaseAndroidBootstrap : PlatformBootstrap
    {
        protected override IEnumerable<Assembly> ViewAssemblies => GetType().Assembly.EncloseInEnumerable();
        protected override IEnumerable<Assembly> PresenterAssemblies => typeof(IMainPresenter).Assembly.EncloseInEnumerable();

        public override async Task RegisterPlatformDependencies(Container container)
        {
            await base.RegisterPlatformDependencies(container);
            container.Register<INavigationService, NavigationService>();
        }
    }
}