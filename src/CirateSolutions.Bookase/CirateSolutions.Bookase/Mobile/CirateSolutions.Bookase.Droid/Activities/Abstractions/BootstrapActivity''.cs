using Android.OS;
using CirateSolutions.Bookase.MVP;

namespace CirateSolutions.Bookase.Droid.Activities.Abstractions
{
    public abstract class BootstrapActivity<TBootstrap, TPlatformBootstrap>
        : BootstrapActivity
        where TBootstrap : Bootstrap
        where TPlatformBootstrap : PlatformBootstrap
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            await Bootstrap.Init<TBootstrap, TPlatformBootstrap>();
        }
    }
}