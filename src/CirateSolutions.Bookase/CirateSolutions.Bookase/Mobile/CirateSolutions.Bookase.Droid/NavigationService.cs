using System;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using CirateSolutions.Bookase.Droid.Activities.Abstractions;
using CirateSolutions.Bookase.Droid.Extensions.FragmentExtensions;
using CirateSolutions.Bookase.MVP;
using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.Droid
{
    public class NavigationService : INavigationService
    {
        private readonly IViewLocator _viewLocator;

        public NavigationService(IViewLocator viewLocator)
        {
            _viewLocator = viewLocator;
        }

        public Task Navigate<TPresenter>(bool addToBackStack = true)
            where TPresenter : IPresenter
            => Navigate(typeof(TPresenter), addToBackStack);

        public Task Navigate(Type presenterType, bool addToBackStack = true)
        {
            var fragmentManager = BootstrapActivity.CurrentActivity.SupportFragmentManager;
            var fragmentTransaction = fragmentManager.BeginTransaction();
            var fragmentType = _viewLocator.GetViewType(presenterType);
            var fragment = Activator.CreateInstance(fragmentType) as Fragment;

            if (addToBackStack)
                fragmentTransaction.AddToBackStack(fragment.FragmentJavaName());

            fragmentTransaction.Add(BootstrapActivity.CurrentActivity.ContentFrameId, fragment);
            fragmentTransaction.Commit();
            return Task.CompletedTask;
        }

        public Task Close()
        {
            if (BootstrapActivity.CurrentActivity.SupportFragmentManager.BackStackEntryCount > 0)
            {
                BootstrapActivity.CurrentActivity.SupportFragmentManager.PopBackStack();
            }
            else
            {
                BootstrapActivity.CurrentActivity.Finish();
            }

            return Task.CompletedTask;
        }
    }
}