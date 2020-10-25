using Android.App;
using CirateSolutions.Bookase.Core;
using CirateSolutions.Bookase.Droid.Activities.Abstractions;

namespace CirateSolutions.Bookase.Droid.Activities
{
    [Activity(Label = "CirateSolutions.Bookase", MainLauncher = true)]
    public class ShellActivity : BootstrapActivity<BookaseBootstrap, BookaseAndroidBootstrap>
    {
        public override int LayoutId => Resource.Layout.Shell;
        public override int ContentFrameId => Resource.Id.ShellContentFrame;
    }
}