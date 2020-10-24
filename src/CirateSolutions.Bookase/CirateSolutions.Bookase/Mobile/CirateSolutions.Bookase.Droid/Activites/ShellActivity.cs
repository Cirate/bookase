using Android.App;
using CirateSolutions.Bookase.Core;
using CirateSolutions.Bookase.Droid.Fragments;

namespace CirateSolutions.Bookase.Droid.Activites
{
    [Activity(Label = "CirateSolutions.Bookase", MainLauncher = true)]
    public class ShellActivity : BootstrapActivity<BookaseBootstrap, MainFragment>
    {
        protected override int LayoutId => Resource.Layout.Shell;
        protected override int ContentFrameId => Resource.Id.ShellContentFrame;
    }
}