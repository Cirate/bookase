using System;
using System.Threading.Tasks;
using CirateSolutions.Bookase.Core.Presenters.Details;
using CirateSolutions.Bookase.Core.Presenters.Details.Interfaces;
using CirateSolutions.Bookase.Core.Presenters.Main;
using CirateSolutions.Bookase.Core.Presenters.Main.Interfaces;
using CirateSolutions.Bookase.MVP;
using SimpleInjector;

namespace CirateSolutions.Bookase.Core
{
    public class BookaseBootstrap : Bootstrap
    {
        protected override Type InitialPresenter => typeof(IMainPresenter);

        protected override async Task RegisterDependencies(Container container)
        {
            await base.RegisterDependencies(container);
            container.Register<IMainPresenter, MainPresenter>();
            container.Register<IDetailsPresenter, DetailsPresenter>();
        }
    }
}