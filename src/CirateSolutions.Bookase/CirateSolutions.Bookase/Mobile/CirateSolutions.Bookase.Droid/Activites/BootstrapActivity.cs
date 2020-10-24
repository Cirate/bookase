using System;
using Android.OS;
using AndroidX.Fragment.App;
using CirateSolutions.Bookase.MVP;

namespace CirateSolutions.Bookase.Droid.Activites
{
    public abstract class BootstrapActivity<TBootstrap, TMainFragment>
        : AndroidX.AppCompat.App.AppCompatActivity
        where TBootstrap : Bootstrap
        where TMainFragment : Fragment
    {
        protected abstract int LayoutId { get; }
        protected abstract int ContentFrameId { get; }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(LayoutId);
            await Bootstrap.Init<TBootstrap>();
            SetUpMainFragment();
        }

        protected void SetUpMainFragment()
        {
            var fragmentManager = SupportFragmentManager;
            var fragmentTransaction = fragmentManager.BeginTransaction();
            var fragment = Activator.CreateInstance<TMainFragment>();
            fragmentTransaction.Add(ContentFrameId, fragment);
            fragmentTransaction.Commit();
        }
    }
}