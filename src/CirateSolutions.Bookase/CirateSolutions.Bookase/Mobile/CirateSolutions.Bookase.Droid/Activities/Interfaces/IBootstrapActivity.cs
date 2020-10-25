using AndroidX.Fragment.App;

namespace CirateSolutions.Bookase.Droid.Activities.Interfaces
{
    public interface IBootstrapActivity
    {
        int LayoutId { get; }
        int ContentFrameId { get; }
        FragmentManager SupportFragmentManager { get; }
        void Finish();
    }
}